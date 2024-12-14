using Godot;

namespace Intuition.UserInterface;
public partial class Reticle : CenterContainer
{
  public CharacterBody3D Player { get; set; }
  private Polygon2D Dot;
  private int dotSize = 4;
  private Color dotColor = Colors.White;

  public override void _Ready()
  {
    Dot = GetNode<Polygon2D>("Dot");
    Player = GetNode<CharacterBody3D>("/root/Main/Player");
    if (Visible)
    {
      Vector2 dotScale = Dot.Scale;
      dotScale.X = dotSize;
      dotScale.Y = dotSize;
      Dot.Scale = dotScale;
      Dot.Color = dotColor;

    }
  }

  private void UpdateReticleSettings()
  {
    if (Dot is Polygon2D)
    {
      Vector2 dotScale = Dot.Scale;
      dotScale.X = dotSize;
      dotScale.Y = dotSize;
      Dot.Scale = dotScale;
      Dot.Color = dotColor;
    }
  }
}
