using Godot;
using Intuition.Extensions;
using System;
namespace Intuition.Players.NPC
{
	public partial class NPCBehavior : CharacterBody3D
	{
		[Export] public float Speed = 0.1f;
		public const float JumpVelocity = 4.5f;
		[Export] public NodePath PathToFollow { get; set; }
		private PathFollow3D _path;

		public AnimationPlayer NPCAnimation => GetNode<AnimationPlayer>("Mesh/AnimationPlayer");

		public void FollowSetPath()
		{
			if (_path is not null)
			{
				_path.ProgressRatio += Speed * (float)GetProcessDeltaTime();
				GlobalTransform = _path.GlobalTransform;
			}
		}

		public void FollowSetPath(PathFollow3D path)
		{
			if (path is not null)
			{
				path.ProgressRatio += Speed * (float)GetProcessDeltaTime();
				GlobalTransform = path.GlobalTransform;
			}
		}

		public override void _Process(double delta)
		{
			FollowSetPath();
		}

		public override void _Ready()
		{
			_path = GetNode<PathFollow3D>(PathToFollow);
			$"Current animation: {NPCAnimation.CurrentAnimation}".ToConsole();
			NPCAnimation.CurrentAnimation = "npc/crawling";
			// NPCAnimation.Play(NPCAnimation.AssignedAnimation);

		}


		public override void _PhysicsProcess(double delta)
		{
			// Vector3 velocity = Velocity;

			// // Add the gravity.
			// if (!IsOnFloor())
			// {
			// 	velocity += GetGravity() * (float)delta;
			// }

			// // Handle Jump.
			// if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			// {
			// 	velocity.Y = JumpVelocity;
			// }

			// // Get the input direction and handle the movement/deceleration.
			// // As good practice, you should replace UI actions with custom gameplay actions.
			// Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
			// Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
			// if (direction != Vector3.Zero)
			// {
			// 	velocity.X = direction.X * Speed;
			// 	velocity.Z = direction.Z * Speed;
			// }
			// else
			// {
			// 	velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			// 	velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
			// }

			// Velocity = velocity;
			// MoveAndSlide();
		}
	}
}

