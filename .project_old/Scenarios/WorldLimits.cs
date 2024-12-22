using Godot;
using Intuition.Extensions;
using System;

namespace Intuition.Scenarios
{
	public partial class WorldLimits : Area3D
	{
		[Signal] public delegate void PlayerDeathEventHandler();
		private void OnBodyExited(Node3D body)
		{
			$"Body out".ToConsole();
			if (body is not CharacterBody3D)
			{
				body.QueueFree();
			}
		}

		private void WaterRisingRoutine(Node3D body)
		{
			$"Water rising\n Body to delete: {body.Name}".ToConsole();
			if (body is not CharacterBody3D)
			{
				body.QueueFree();
			}
			else
			{
				EmitSignal(SignalName.PlayerDeath);
			}
		}
	}
}

