using Godot;
namespace Intuition.Extensions
{
    public static class RigidBodyExtensions
    {
        public static void MoveRigidBodyTowardsObject(this RigidBody3D body, Node3D target, int lerpSpeed)
        {
            var speed = lerpSpeed * body.GlobalTransform.Origin.DistanceTo(target.GlobalTransform.Origin);
            var direction = body.GlobalTransform.Origin.DirectionTo(target.GlobalTransform.Origin);
            body.LinearVelocity = Vector3.Zero;
            body.ApplyCentralForce(direction * speed);

            body.GravityScale = 0;
        }
    }
}