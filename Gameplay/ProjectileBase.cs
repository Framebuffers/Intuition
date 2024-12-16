using Godot;
using Intuition.Extensions;
using System;
namespace Intuition.Gameplay
{
	public partial class ProjectileBase : RigidBody3D
	{
		private void OnCollisionEvent(Node3D body)
		{
			$"Collided with {body.Name}".ToConsole();
		}
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}
	}
}

