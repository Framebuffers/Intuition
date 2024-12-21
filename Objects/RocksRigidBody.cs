using Godot;
using Intuition.Camera;
using Intuition.Extensions;
namespace Intuition.Objects;
public partial class RocksRigidBody : RigidBody3D
{
    [Signal] public delegate void DeathEventHandler();

    private void OnHit(Node body)
    {
        // if (body is Player)
        $"Player hit: {body.Name}".ToConsole();
        EmitSignal(SignalName.Death);
    }
}