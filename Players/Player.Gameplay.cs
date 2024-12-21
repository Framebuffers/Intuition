using Godot;
using Intuition.Extensions;

namespace Intuition.Camera
{
    public sealed partial class Player : StairsCharacter
    {
        public Main MainLoop => GetNode<Main>("/root/Main");

        private void OnCollision()
        {
            // if (CeilingDetection.IsColliding())
            {
                // $"Colliding with {CeilingDetection.Get}"
            }
        }
    }
}