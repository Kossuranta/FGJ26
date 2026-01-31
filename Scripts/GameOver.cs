using Godot;

public partial class GameOver : Control
{
	private const string GameLevelScenePath = "res://Scenes/game_level.tscn";

	[Export] public Button RestartButton { get; set; }
	[Export] public Button QuitButton { get; set; }

	[Export] public Control WinRoot { get; set; }
	[Export] public Control LoseRoot { get; set; }

	[Export] public Label ScoreLabel { get; set; }

	public override void _Ready()
	{
		ValidateExports();

		if (RestartButton != null)
		{
			RestartButton.Pressed += OnRestartPressed;
		}

		if (QuitButton != null)
		{
			QuitButton.Pressed += OnQuitPressed;
		}

		bool won = GameManager.LastGameWon;

		if (WinRoot != null)
		{
			WinRoot.Visible = won;
		}

		if (LoseRoot != null)
		{
			LoseRoot.Visible = !won;
		}

		if (ScoreLabel != null)
		{
			ScoreLabel.Text = GameManager.LastFinalScore.ToString();
		}
	}

	private void ValidateExports()
	{
		if (RestartButton == null)
		{
			GD.PrintErr("GameOver: RestartButton is not assigned!");
		}

		if (QuitButton == null)
		{
			GD.PrintErr("GameOver: QuitButton is not assigned!");
		}

		if (WinRoot == null)
		{
			GD.PrintErr("GameOver: WinRoot is not assigned!");
		}

		if (LoseRoot == null)
		{
			GD.PrintErr("GameOver: LoseRoot is not assigned!");
		}

		if (ScoreLabel == null)
		{
			GD.PrintErr("GameOver: ScoreLabel is not assigned!");
		}
	}

	private void OnRestartPressed()
	{
		GetTree().ChangeSceneToFile(GameLevelScenePath);
	}

	private void OnQuitPressed()
	{
		GetTree().Quit();
	}
}

