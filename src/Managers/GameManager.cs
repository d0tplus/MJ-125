using Godot;
using System;

public partial class GameManager : Node
{
	private static int _gameScore;
	private static int _highScore;

	public override void _Ready()
	{
		var lossZone = GetTree().Root.GetNode<LoseZone>("World/LossZone");
		lossZone.BeatEnteredLoseZone += EndGame;
	}

	public static void AddPoint(int pointValue)
	{
		_gameScore += pointValue;
	}

	private void UpdateHighScores()
	{
		if (_highScore < _gameScore)
		{
			_highScore = _gameScore;
		}
	}

	private void EndGame()
	{
		GetTree().Paused = true;
		UpdateHighScores();
	}
}
