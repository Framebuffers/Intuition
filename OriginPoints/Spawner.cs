using Godot;
using Intuition.Extensions;
using Intuition.Gameplay;
using Intuition.Objects;
using System;
using System.Diagnostics;
namespace Intuition.OriginPoints
{
	/// <summary>
	/// Loads a <see cref="PackedScene"/>, and, when <see cref="ShootProjectile()"/> is called, it instantiates the scene and shoots it applying the set <see cref="ForceApplied"/>.
	/// </summary>
	public partial class Spawner : Marker3D
	{
		[Signal] public delegate void ActivateSpawnerEventHandler();
		[Export] public PackedScene Projectile { get; set; }
		[Export] public int ForceApplied { get; set; } = 10;
		private Stopwatch _time;
		private bool Shoot;
		public void ShootProjectile()
		{
			RigidBody3D r = (RigidBody3D)Projectile.Instantiate();
			AddChild(r);
			r.ShootFrom(this, GD.RandRange(10, 30));
		}

		public void StartShootingAtPlayer()
		{
			_time = new();
			_time.Start();
			Shoot = true;
		}

		public override void _Process(double delta)
		{
			if (Shoot)
			{
				var randomShoot = GD.RandRange(2, 5);
				if (_time.Elapsed.Seconds >= randomShoot)
				{
					ShootProjectile();
					_time = new();
					_time.Start();
				}

			}
		}

		// public override void _UnhandledInput(InputEvent @event)
		// {
		// 	if (@event is InputEventMouseButton i)
		// 	{
		// 		if (i.ButtonIndex == MouseButton.Left)
		// 			ShootProjectile();
		// 	}
		// }


	}
}

