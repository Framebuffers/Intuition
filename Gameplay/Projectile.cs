using Godot;
using Intuition.Extensions;
namespace Intuition.Gameplay
{
    public partial class Projectile : RigidBody3D
    {
        [Export] public int ForceApplied { get; set; } = 1000;
    }
}