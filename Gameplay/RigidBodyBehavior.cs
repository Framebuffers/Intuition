using Godot;

namespace Intuition.Gameplay
{
    public partial class RigidBodyBehavior : RigidBody3D
    {

        // Godot docs implementation
        private float _speed = 0.1f;
        private void LookFollow(PhysicsDirectBodyState3D state, Transform3D currentTransform, Vector3 targetPosition)
        {
            Vector3 forwardLocalAxis = new Vector3(1, 0, 0);
            Vector3 forwardDir = (currentTransform.Basis * forwardLocalAxis).Normalized();
            Vector3 targetDir = (targetPosition - currentTransform.Origin).Normalized();
            float localSpeed = Mathf.Clamp(_speed, 0.0f, Mathf.Acos(forwardDir.Dot(targetDir)));
            if (forwardDir.Dot(targetDir) > 1e-4)
            {
                state.AngularVelocity = forwardDir.Cross(targetDir) * localSpeed / state.Step;
            }
        }

        public override void _IntegrateForces(PhysicsDirectBodyState3D state)
        {
            Vector3 targetPosition = GetNode<CharacterBody3D>("/root/Main/Player").GlobalTransform.Origin;
            LookFollow(state, GlobalTransform, targetPosition);
        }
        // ---------------------------------------------------------

        public override void _Ready()
        {
        }

        public override void _PhysicsProcess(double delta)
        {
        }

        public override void _Process(double delta)
        {
        }




    }
}