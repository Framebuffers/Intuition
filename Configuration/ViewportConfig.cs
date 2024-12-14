using Godot;
using Intuition.Extensions;

namespace Intuition.Configuration;

public static class ViewportConfiguration
{
  public static Vector2I WindowSize { get => DisplayServer.WindowGetSize(); set => DisplayServer.WindowSetSize(value); }
  public static Vector2I WindowPosition { get => DisplayServer.WindowGetPosition(); set => DisplayServer.WindowSetPosition(value); }
  public static DisplayServer.WindowMode Mode { get => DisplayServer.WindowGetMode(); set => DisplayServer.WindowSetMode(value); }
  public static Variant ScaleFactor { get => ProjectSettings.GetSettingWithOverride("display/window/stretch/scale"); set => ProjectSettings.SetSetting("display/window/stretch/scale", value); }
  public static Variant ScaleMode3D { get => ProjectSettings.GetSettingWithOverride("rendering/scaling_3d/scale"); set => ProjectSettings.SetSetting("rendering/scaling_3d/scale", value); }
  public static Godot.DisplayServer.VSyncMode Vsync { get => Godot.DisplayServer.WindowGetVsyncMode(); set => Godot.DisplayServer.WindowSetVsyncMode(value); }

  public static void ConfigureScale(Window w, float scaleFactor, Window.Scaling3DModeEnum scalingMode)
  {
    ScaleFactor = Mathf.Wrap(scaleFactor + 1.0f, 1.0f, 4.0f);
    w.Scaling3DScale = 1.0f / (float)ScaleFactor;
    $"Scale: {3.0f % 100 / (float)ScaleFactor}".ToConsole();
    w.Scaling3DMode = scalingMode;
  }
}

