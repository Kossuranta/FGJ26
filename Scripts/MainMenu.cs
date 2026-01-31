using Godot;

public partial class MainMenu : Control
{
	[Export] public Button StartButton { get; set; }
	[Export] public Button QuitButton { get; set; }

	public override void _Ready()
	{
		if (StartButton == null)
		{
			GD.PrintErr("MainMenu: StartButton is not assigned!");
		}

		if (QuitButton == null)
		{
			GD.PrintErr("MainMenu: QuitButton is not assigned!");
		}

		StartButton.Pressed += OnStartPressed;
		QuitButton.Pressed += OnQuitPressed;
	}

	private void OnStartPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/game_level.tscn");
	}

	private void OnQuitPressed()
	{
		GetTree().Quit();
	}
}
