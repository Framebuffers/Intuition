using Godot;
using Intuition.Extensions;
using Intuition.Gameplay;
using System;
namespace Intuition.OriginPoints;
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
