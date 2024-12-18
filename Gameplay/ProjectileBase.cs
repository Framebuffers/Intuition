using Godot;
using Intuition.Camera;
using Intuition.Extensions;
using System;
namespace Intuition.Gameplay
{
	public partial class ProjectileBase : RigidBody3D
	{
		// [Signal] public delegate void PlayerCollisionEventHandler();

		private void OnCollisionEvent(Node3D body)
		{
			if (body is Player p)
			{
				// EmitSignal(SignalName.PlayerCollision);
			}
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

