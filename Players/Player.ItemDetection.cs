namespace Intuition.Camera;

using Godot;
using Intuition.Extensions;

public sealed partial class Player : StairsCharacter
{
  private ShapeCast3D CeilingDetection;
  public Area3D DetectedItem { get; set; }

  [Signal] public delegate void HideItemEventHandler();
  [Signal] public delegate void ShowItemEventHandler();
  [Signal] public delegate void ElementDetectedEventHandler();

  bool itemDetected = false;
  bool itemEnabled = false;
  bool lowCeiling = false; // NOTE: This is for when the ceiling is too low and the player needs to crouch.
  bool wasGrounded = true; // NOTE: useful for stair calc.

  private void InitItemDetection()
  {
    CeilingDetection = GetNode<ShapeCast3D>("CrouchCeilingDetection");
  }


  // NOTE: Item detection. Now this one is hella complex and needs to be split up.
  // It casts a ray from the camera centre to the nearest Area3D, and emits the ShowItem or HideItem signal.
  // These should be more "generic" since they can be useful to detect _anything_ in front of the camera.
  // Right now it is coupled to one type <Area3D>, but should be able to extend to other types.
  // Other ideas involve: returning the collider, querying data from PhysicsServer3D, etc.
  //  private Node3D LastItem { get; set; }
  private void DetectItems()
  {
    var spaceState = GetWorld3D().DirectSpaceState;
    var mousePosition = GetViewport().GetMousePosition();
    var rayLength = 10.0f;
    var origin = Camera.ProjectRayOrigin(mousePosition);
    var end = origin + Camera.ProjectRayNormal(mousePosition) * rayLength;
    var query = PhysicsRayQueryParameters3D.Create(origin, end);
    query.CollideWithAreas = true;

    var result = spaceState.IntersectRay(query);
    if (result.Count > 0)
    {
      var obj = result["collider"].AsGodotObject();
      if (obj is Area3D)
      {
        itemDetected = true;
        DetectedItem = obj as Area3D;
        EmitSignal(SignalName.ElementDetected);
        //EmitSignal(SignalName.ShowItem);
      }
      else
      {
        itemDetected = false;
        EmitSignal(SignalName.HideItem);
        itemEnabled = false;
      }
    }
  }

  private void HandleItemDetection()
  {
    $"Item enabled: {itemEnabled}\nItem detected: {itemDetected}".ToConsole();
    if (itemDetected)
    {
      EmitSignal(SignalName.ShowItem);
      $"Showing item: {DetectedItem.Name}".ToConsole();
      itemEnabled = true;
    }
    else
    {
      EmitSignal(SignalName.HideItem);
      $"Hiding item".ToConsole();
      itemEnabled = false;
      itemDetected = false;
    }
  }
}
