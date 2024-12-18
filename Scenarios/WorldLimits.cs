using Godot;
using Intuition.Extensions;
using System;

namespace Intuition.Scenarios
{
	public partial class WorldLimits : Area3D
	{
		private void OnBodyExited(Node3D body)
		{
			$"Body out".ToConsole();
			if (body is not CharacterBody3D)
			{
				body.QueueFree();
			}

			// body.QueueFree();
		}
	}
}

