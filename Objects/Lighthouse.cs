using Godot;
using System;
namespace Intuition.Objects;
public partial class Lighthouse : Node3D
{
	private MeshInstance3D Lights => GetNode<MeshInstance3D>("MeshInstance3D");
	private Tween LightTween { get; set; }
	public float Duration { get; set; } = 10.0f;
	public void OnCompletion()
	{
		ActivateLight();
	}
	public void ActivateLight()
	{
		LightTween = Lights.CreateTween();
		LightTween.TweenProperty(Lights, "rotation_degrees:y", 360.0f, Duration);
		LightTween.Finished += GoBack;
	}

	private void GoBack()
	{
		LightTween = Lights.CreateTween();
		LightTween.TweenProperty(Lights, "rotation_degrees:y", -360.0f, Duration);
		LightTween.Finished += ActivateLight;
	}

	public override void _Ready()
	{
		// ActivateLight();
	}
}
