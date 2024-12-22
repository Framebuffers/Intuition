using System;
using Godot;
using Intuition.Extensions;
namespace Intuition
{
    public partial class Main : Node3D
    {
        public void OnDeath()
        {
            $"Player is dead".ToConsole();
        }

    }
}