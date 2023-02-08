using Godot;
using System;

public partial class Beat : Node3D
{
	public float Speed = 0.09f;
	private int _pointValue = 100;
	private float _deathShakeValue = 7;

	public override void _Process(double delta)
	{
		Position += new Vector3(0,0, Speed);
	}

	// Rename to collisionBox
	private void OnEnterHurtBox(Area3D area)
	{ 
		if (area.IsInGroup("Projectile"))
		{
			GameManager.AddPoint(_pointValue);
			QueueFree();
		}
	}
}
