using Godot;
namespace Intuition.Gameplay
{
    public partial class PlayerSpawner : Marker3D
    {
        private Main Game => GetNode<Main>("/root/Main");
        private void MoveHere(CharacterBody3D c) => c.GlobalPosition = GlobalPosition;
    }
}