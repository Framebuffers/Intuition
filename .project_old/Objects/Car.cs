using Godot;
using Intuition.Extensions;
using System;

namespace Intuition.Objects
{
	public partial class Car : RigidBody3D
	{
		// public RigidBody3D RigidBody => GetNode<RigidBody3D>("RigidBody3D");
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{

			// Shoot(2000);
		}


		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}

		public override void _PhysicsProcess(double delta)
		{
			base._PhysicsProcess(delta);
		}
	}
}

