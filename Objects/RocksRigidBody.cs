using System.Diagnostics;
using Godot;
using Intuition.Camera;
using Intuition.Extensions;
namespace Intuition.Objects;
public partial class RocksRigidBody : RigidBody3D
{
    [Signal] public delegate void DeathEventHandler();

    private void OnHit(Node body)
    {

        if (body is Player)
            EmitSignal(SignalName.Death);
        OnGround();
    }

    private void OnGround()
    {
        SceneTreeTimer t = GetTree().CreateTimer(15f);
        // t.
        t.Timeout += QueueFree;
    }
}