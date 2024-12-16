using Godot;
using Intuition.Extensions;
using System;

namespace Intuition.Gameplay
{
	public partial class Shooter : Node3D
	{
		[Export]
		public PackedScene ProjectileScene { get; set; }

		[Export]
		public NodePath ShootPointPath { get; set; }

		private Node3D shootPoint;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			shootPoint = GetNode<Node3D>(ShootPointPath);
		}

		// public void Shoot()
		// {
		// 	var projectile = (RigidBody3D)ProjectileScene.Instantiate();
		// 	projectile.Shoot(GetNode<CharacterBody3D>("/root/Player"), 1500);
		// }

		public override void _Input(InputEvent @event)
		{
			// if (@event is InputEventKey eventKey && eventKey.Pressed && eventKey.Keycode == Key.K) { Shoot(); }
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}
	}
}

