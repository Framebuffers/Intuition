using Godot;
namespace Intuition.Camera
{
    // Make the world stop when you're not moving.
    //
    // Use Godot's pause system, and make the player process always, no matter the state.
    public sealed partial class Player : StairsCharacter
    {
        [Signal] public delegate void PlayerCollisionEventHandler(RigidBody3D source);
        public bool EnableTimestop = false;
        private void HandleTimestop()
        {
            if (EnableTimestop)
            {
                this.ProcessMode = ProcessModeEnum.Always;
                GetTree().Paused = true;

                if (Input.IsAnythingPressed())
                {
                    GetTree().Paused = false;
                }
            }
        }
    }

}