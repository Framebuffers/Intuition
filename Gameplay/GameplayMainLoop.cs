using Godot;
using Intuition.Extensions;
using System;
using System.Linq;

public partial class GameplayMainLoop : Node3D
{
	// Gameplay loop
	//
	// 1. Game is paused by default.
	// 2. On InputKey == WASD/Arrows, unpause the game.
	// 3. Check for collisions with the player.
	// 4. If something hits the player, game over.
	// 5. Calculate physics for objects being thrown.


	// private RigidBody3D ThrowableBody => GetNode<RigidBody3D>("/root/Main/ScreenManager/SceneManager/RigidBody3D");
	private Node3D Target => GetNode<Node3D>("/root/Main/Player/Head");
	private Vector3 TargetPosition => Target.GlobalTransform.Origin;

	private bool IsThrowable = false;
	private const int LerpSpeed = 5;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey eventKey && eventKey.Pressed && eventKey.Keycode == Key.T)
		{
			IsThrowable = true;
		}

	}



	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		// if (IsThrowable)
		// {
		// 	ThrowableBody.MoveRigidBodyTowardsObject(Target, (int)GD.RandRange(3.0, 10.0));
		// 	IsThrowable = false;
		// }
		// else
		// {
		// 	ThrowableBody.GravityScale = 1;
		// 	IsThrowable = true;
		// }
	}

}
