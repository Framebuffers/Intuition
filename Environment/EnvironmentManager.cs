using Godot;
using Intuition.Extensions;
namespace Intuition.Environment
{
    public partial class EnvironmentManager : Node3D
    {
        [Signal] public delegate void OnMorningEventHandler();
        [Signal] public delegate void OnEveningEventHandler();
        [Signal] public delegate void OnNightEventHandler();
        [Signal] public delegate void OnAlertEventHandler();

        private Main Main => GetNode<Main>("/root/Main");

        // Environment presets
        public static Godot.Environment GetMorning() => ResourceLoader.Load<Godot.Environment>("res://Environment/Intuition_Day_1.tres");
        public static Godot.Environment GetEvening() => ResourceLoader.Load<Godot.Environment>("res://Environment/Intuition_Day_2.tres");
        public static Godot.Environment GetDay() => ResourceLoader.Load<Godot.Environment>("res://Environment/Intuition_Day_3.tres");
        public static Godot.Environment GetNight() => ResourceLoader.Load<Godot.Environment>("res://Environment/Intuition_Night.tres");
        // public static Godot.Environment GetAlert() => ResourceLoader.Load<Godot.Environment>("res://Environment/Intuition_Day_1.tres");
        public static Godot.Environment GetNegative() => ResourceLoader.Load<Godot.Environment>("res://Environment/Intuition_Negative.tres");
        public static Godot.Environment GetFog() => ResourceLoader.Load<Godot.Environment>("res://Environment/Intuition_Fog.tres");
        public static Godot.Environment GetEvening_2() => ResourceLoader.Load<Godot.Environment>("res://Environment/Intuition_Day4.tres");

        // Lights
        public DirectionalLight3D MorningLight => GetNode<DirectionalLight3D>("/root/Main/ScreenManager/EnvironmentManager/DayLighting/Daylight_Orange");
        public DirectionalLight3D NightLight => GetNode<DirectionalLight3D>("/root/Main/ScreenManager/EnvironmentManager/NightLighting/Orange");
        public DirectionalLight3D Alert1Light => GetNode<DirectionalLight3D>("/root/Main/ScreenManager/EnvironmentManager/AlertLighting/Red1");
        public DirectionalLight3D Alert2Light => GetNode<DirectionalLight3D>("/root/Main/ScreenManager/EnvironmentManager/AlertLighting/Red2");
        public DirectionalLight3D EditorLight => GetNode<DirectionalLight3D>("/root/Main/ScreenManager/EnvironmentManager/Editor/DirectionalLight3D");

        public Tween ModeTransition { get; set; }

        public float TimeToChangeLightingMode { get; set; } = 60.0f;
        public void OnSwitchingState()
        {
            Main.GameEnvironment = Main.EnvironmentMode.Alert;

            EmitSignal(SignalName.OnAlert);
            // handle mode change
        }

        public void LoadEnvironment(int randomEnvironment, int combinationLight = 0)
        {
            $"randomEnvironment = {randomEnvironment}, combinationLight = {combinationLight}".ToConsole();
            switch (combinationLight)
            {
                case 0:
                    Alert1Light.Visible = false;
                    Alert2Light.Visible = false;
                    EditorLight.Visible = false;
                    NightLight.Visible = false;
                    MorningLight.Visible = true;

                    ModeTransition = GetTree().CreateTween();
                    ModeTransition.BindNode(MorningLight);
                    ModeTransition.TweenProperty(MorningLight, "rotation_degrees:x", 360.0f, TimeToChangeLightingMode);
                    ModeTransition.Finished += OnSwitchingState;
                    $"MorningLight on".ToConsole();
                    break;
                case 1:
                default:
                    Alert1Light.Visible = false;
                    Alert2Light.Visible = false;
                    EditorLight.Visible = false;
                    NightLight.Visible = false;
                    MorningLight.Visible = false;

                    Timer t = new();
                    AddChild(t);
                    t.Start(TimeToChangeLightingMode);
                    t.Timeout += OnSwitchingState;
                    $"MorningLight off".ToConsole();
                    break;
            }

            switch (randomEnvironment)
            {
                case 0:
                    Main.GameEnvironment = Main.EnvironmentMode.Morning;
                    Main.WorldEnvironment.Environment = GetMorning();
                    EmitSignal(SignalName.OnMorning);
                    break;
                case 1:
                    Main.GameEnvironment = Main.EnvironmentMode.Evening;
                    Main.WorldEnvironment.Environment = GetEvening();
                    // need to force light to be on, or it looks all blue.
                    Alert1Light.Visible = false;
                    Alert2Light.Visible = false;
                    EditorLight.Visible = false;
                    NightLight.Visible = false;
                    MorningLight.Visible = true;
                    EmitSignal(SignalName.OnEvening);

                    ModeTransition = GetTree().CreateTween();
                    ModeTransition.BindNode(MorningLight);
                    ModeTransition.TweenProperty(MorningLight, "rotation_degrees:x", 360.0f, TimeToChangeLightingMode);
                    ModeTransition.Finished += OnSwitchingState;
                    break;
                case 2:
                    Main.GameEnvironment = Main.EnvironmentMode.Evening;
                    Main.WorldEnvironment.Environment = GetDay();
                    EmitSignal(SignalName.OnEvening);
                    break;
                case 3:
                    Main.GameEnvironment = Main.EnvironmentMode.Morning;
                    Main.WorldEnvironment.Environment = GetFog();
                    EmitSignal(SignalName.OnMorning);
                    break;
                case 4:
                    Main.GameEnvironment = Main.EnvironmentMode.Evening;
                    Main.WorldEnvironment.Environment = GetEvening_2();
                    EmitSignal(SignalName.OnMorning);
                    break;
                case 5:
                    Main.GameEnvironment = Main.EnvironmentMode.Night;
                    Main.WorldEnvironment.Environment = GetNight();

                    Alert1Light.Visible = false;
                    Alert2Light.Visible = false;
                    EditorLight.Visible = false;
                    NightLight.Visible = true;
                    MorningLight.Visible = false;
                    EmitSignal(SignalName.OnNight);

                    ModeTransition = GetTree().CreateTween();
                    ModeTransition.BindNode(NightLight);
                    ModeTransition.TweenProperty(NightLight, "rotation_degrees:x", 360.0f, TimeToChangeLightingMode);
                    ModeTransition.Finished += OnSwitchingState;
                    break;
                case 6:
                    Main.GameEnvironment = Main.EnvironmentMode.Night;
                    LoadEnvironmentNightBright();
                    EmitSignal(SignalName.OnNight);

                    ModeTransition = GetTree().CreateTween();
                    ModeTransition.BindNode(NightLight);
                    ModeTransition.TweenProperty(NightLight, "rotation_degrees:x", 360.0f, TimeToChangeLightingMode);
                    ModeTransition.Finished += OnSwitchingState;
                    break;
                default:
                    Alert1Light.Visible = false;
                    Alert2Light.Visible = false;
                    EditorLight.Visible = false;
                    NightLight.Visible = false;
                    MorningLight.Visible = true;
                    Main.GameEnvironment = Main.EnvironmentMode.Morning;
                    Main.WorldEnvironment.Environment = GetMorning();
                    EmitSignal(SignalName.OnMorning);

                    ModeTransition = GetTree().CreateTween();
                    ModeTransition.BindNode(MorningLight);
                    ModeTransition.TweenProperty(MorningLight, "rotation_degrees:x", 360.0f, TimeToChangeLightingMode);
                    ModeTransition.Finished += OnSwitchingState;
                    break;
            }

        }

        public void LoadEnvironmentNight()
        {
            Alert1Light.Visible = false;
            Alert2Light.Visible = false;
            EditorLight.Visible = false;
            NightLight.Visible = true;
            MorningLight.Visible = false;

            Main.GameEnvironment = Main.EnvironmentMode.Night;
            Main.WorldEnvironment.Environment = GetNight();
        }

        public void LoadEnvironmentNightBright()
        {
            Alert1Light.Visible = false;
            Alert2Light.Visible = false;
            EditorLight.Visible = true;
            NightLight.Visible = true;
            MorningLight.Visible = false;

            Main.GameEnvironment = Main.EnvironmentMode.Night;
            Main.WorldEnvironment.Environment = GetNight();
        }

        public void LoadEnvironmentNightAlert1()
        {
            Alert1Light.Visible = true;
            Alert2Light.Visible = false;
            EditorLight.Visible = true;
            NightLight.Visible = true;
            MorningLight.Visible = false;

            Main.GameEnvironment = Main.EnvironmentMode.Alert;
            Main.WorldEnvironment.Environment = GetNight();
        }

        public void LoadEnvironmentNightAlert2()
        {
            Alert1Light.Visible = true;
            Alert2Light.Visible = true;
            EditorLight.Visible = true;
            NightLight.Visible = true;
            MorningLight.Visible = false;

            Main.GameEnvironment = Main.EnvironmentMode.Alert;
            Main.WorldEnvironment.Environment = GetNight();
        }

        public void LoadEnvironmentDayAlert()
        {
            Alert1Light.Visible = true;
            Alert2Light.Visible = true;
            EditorLight.Visible = false;
            NightLight.Visible = false;
            MorningLight.Visible = false;

            Main.GameEnvironment = Main.EnvironmentMode.Alert;
        }

        public void LoadEnvironmentDeath() => Main.WorldEnvironment.Environment = GetNegative();
        // public void FoggySunset()
        // {
        //     Alert1Light.Visible = true;
        //     Alert2Light.Visible = false;
        //     EditorLight.Visible = false;
        //     NightLight.Visible = false;
        //     MorningLight.Visible = false;

        //     Main.GameEnvironment = Main.EnvironmentMode.Evening;
        //     Main.WorldEnvironment.Environment = GetEvening_2();
        // }

        // public void EarlyMorning()
        // {
        //     Alert1Light.Visible = false;
        //     Alert2Light.Visible = false;
        //     EditorLight.Visible = false;
        //     NightLight.Visible = false;
        //     MorningLight.Visible = true;

        //     Main.GameEnvironment = Main.EnvironmentMode.Morning;
        //     Main.WorldEnvironment.Environment = GetEvening_2();
        // }

        // public void FoggyBrightMorning()
        // {
        //     Alert1Light.Visible = false;
        //     Alert2Light.Visible = false;
        //     EditorLight.Visible = true;
        //     NightLight.Visible = false;
        //     MorningLight.Visible = false;

        //     Main.GameEnvironment = Main.EnvironmentMode.Morning;
        //     Main.WorldEnvironment.Environment = GetFog();
        // }




    }
}