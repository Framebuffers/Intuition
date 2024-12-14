using Godot;
using ViewportConfiguration = Intuition.Configuration.ViewportConfiguration;
using TextPanel = Intuition.UserInterface.TextPanel;

namespace Intuition;

public partial class Main : Node3D
{
  //  private TextPanel TextPanel;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    ViewportConfiguration.ConfigureScale(
        GetWindow(),
        1.0f,
        Viewport.Scaling3DModeEnum.Nearest);

    //  TextPanel = GetNode<PanelContainer>("/root/Main/GUIPanel2D/UserInterface/DebugPanel") as TextPanel;
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta) { }
}
