using Godot;
using System;

public partial class Spawner : Node3D
{
	[Export] private PackedScene _beat;
	private Random _randomGen;
	public override void _Ready()
	{
		_randomGen = new Random();
	}

	private Vector3 SetSpawnPosition()
	{
		float zPosition = (float) _randomGen.NextDouble() * 2; // (max - min) + min, in our case we using 2 x-length and 0 z-height
		return new Vector3(zPosition, 0.25f, 0f);
	}
	private void SpawnNote()
	{
		var beat = _beat.Instantiate<Beat>();
		beat.Position = SetSpawnPosition();
		GetTree().Root.GetNode("World").AddChild(beat);
	}
	private void OnTimeOut()
	{
		SpawnNote();
	}
}
