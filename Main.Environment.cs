using System;
using Godot;
using Intuition.Environment;
using Intuition.Extensions;
namespace Intuition
{
    public partial class Main : Node3D
    {
        public WorldEnvironment WorldEnvironment => GetNode<WorldEnvironment>("/root/Main/ScreenManager/EnvironmentManager/WorldEnvironment");
        public EnvironmentMode GameEnvironment { get; set; }
        public EnvironmentManager EnvironmentManager => GetNode<EnvironmentManager>("ScreenManager/EnvironmentManager");

        private void LoadRandomEnvironment()
        {
            EnvironmentManager.LoadEnvironment(GD.RandRange(0, 6), GD.RandRange(0, 1));
            $"Environment number: {GameEnvironment}, EnvironmentResource: {WorldEnvironment.Environment.ResourcePath}".ToConsole();
        }
        private void LoadEnvironmentOnDateTime()
        {
            if (DateTime.Now.IsBetween(TimeSpan.Parse("06:00"), TimeSpan.Parse("12:00")))
            {
                GameEnvironment = EnvironmentMode.Morning;
            }

            if (DateTime.Now.IsBetween(TimeSpan.Parse("12:00"), TimeSpan.Parse("21:00")))
            {
                GameEnvironment = EnvironmentMode.Evening;
            }

            if (DateTime.Now.IsBetween(TimeSpan.Parse("21:00"), TimeSpan.Parse("06:00")))
            {
                GameEnvironment = EnvironmentMode.Night;
            }
        }

        private void TestModeSwitch()
        {
            EnvironmentManager.TimeToChangeLightingMode = 5.0f;
            EnvironmentManager.LoadEnvironment(GD.RandRange(0, 6), GD.RandRange(0, 1));
            $"Environment number: {GameEnvironment}, EnvironmentResource: {WorldEnvironment.Environment.ResourcePath}".ToConsole();
            Player.EnableTimestop = true;
        }

        private void LoadRandomEnvironmentMode()
        {
            int randEnv = GD.RandRange(0, Enum.GetNames(typeof(EnvironmentMode)).Length - 1);
            GameEnvironment = (EnvironmentMode)randEnv;
        }
    }
}