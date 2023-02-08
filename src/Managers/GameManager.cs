using Godot;
using System;

public partial class GameManager : Node
{
	private static int _gameScore;
	private static int _highScore;
	private static Label _scoreLabel;
	private static Label _highScoreLabel;

	public override void _Ready()
	{
		var lossZone = GetTree().Root.GetNode<LoseZone>("World/LossZone");
		_scoreLabel = GetTree().Root.GetNode<Label>("World/Canvas/HUD/ScoreDisplay/Points");
		_highScoreLabel = GetTree().Root.GetNode<Label>("World/Canvas/HUD/HighScoreDisplay/Points");
		lossZone.BeatEnteredLoseZone += EndGame;
	}

	public static void AddPoint(int pointValue)
	{
		_gameScore += pointValue;
		_scoreLabel.Text = _gameScore.ToString();
	}

	private void UpdateHighScores()
	{
		if (_highScore < _gameScore)
		{
			_highScore = _gameScore;
			_highScoreLabel.Text = _highScore.ToString();
		}
	}

	private void EndGame()
	{
		GetTree().Paused = true;
		UpdateHighScores();
	}
}
