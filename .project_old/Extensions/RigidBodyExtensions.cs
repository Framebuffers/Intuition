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

        public static void Shoot(this RigidBody3D projectile, int forceApplied = 1000)
        {
            // projectile.GlobalTransform = projectile.GlobalTransform;
            Vector3 shootingDirection = projectile.GlobalTransform.Basis.Z.Normalized();
            projectile.ApplyCentralImpulse(shootingDirection * forceApplied);
        }

        public static void ShootFrom(this RigidBody3D projectile, Node3D originPoint, int forceApplied = 1000)
        {
            projectile.GlobalTransform = originPoint.GlobalTransform;
            Vector3 shootingDirection = projectile.GlobalTransform.Basis.Z.Normalized();
            projectile.ApplyCentralImpulse(shootingDirection * forceApplied);
        }

        public static void ShootTowards(this RigidBody3D projectile, Node3D target, int forceApplied = 1000)
        {
            projectile.LookAtFromPosition(projectile.GlobalPosition, target.GlobalPosition, Vector3.Up);
            projectile.ApplyCentralImpulse(projectile.GlobalTransform.Basis.Z.Normalized() * forceApplied);
        }

    }
}