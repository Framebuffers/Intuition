using Godot;
using Intuition.Extensions;
using Intuition.Gameplay;
using Intuition.Objects;
using System;
namespace Intuition.OriginPoints
{
	/// <summary>
	/// Loads a <see cref="PackedScene"/>, and, when <see cref="ShootProjectile()"/> is called, it instantiates the scene and shoots it applying the set <see cref="ForceApplied"/>.
	/// </summary>
	public partial class Spawner : Marker3D
	{
		[Export] public PackedScene Projectile { get; set; }
		[Export] public int ForceApplied { get; set; } = 10;

		public void ShootProjectile()
		{
			RigidBody3D r = (RigidBody3D)Projectile.Instantiate();
			AddChild(r);
			r.ShootFrom(this, 10);
		}

		public override void _UnhandledInput(InputEvent @event)
		{
			if (@event is InputEventMouseButton i)
			{
				if (i.ButtonIndex == MouseButton.Left)
					ShootProjectile();
			}
		}


	}
}

