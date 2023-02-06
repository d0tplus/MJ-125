using Godot;
using System;

public partial class Projectile : Node3D
{
	public float Speed = -0.09f;
	public override void _Process(double delta)
	{
		Position += new Vector3(0,0, Speed);
	}

	private void OnEnterHitBox(Area3D area)
	{
		if (area.IsInGroup("Beat"))
		{
			QueueFree();
		}
	}
}
