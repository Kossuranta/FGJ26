using Godot;

public partial class PauseMenu : Control
{
	[Export] public Button ContinueButton { get; set; }
	[Export] public Button QuitButton { get; set; }
	[Export] public Button PauseButton { get; set; }

	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;
		Visible = false;

		if (ContinueButton != null)
		{
			ContinueButton.Pressed += OnContinuePressed;
		}
		else
		{
			GD.PrintErr("PauseMenu: ContinueButton is not assigned!");
		}

		if (QuitButton != null)
		{
			QuitButton.Pressed += OnQuitPressed;
		}
		else
		{
			GD.PrintErr("PauseMenu: QuitButton is not assigned!");
		}

		if (PauseButton != null)
		{
			PauseButton.Pressed += TogglePause;
		}
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_cancel"))
		{
			TogglePause();
		}
	}

	public void TogglePause()
	{
		bool isPaused = !GetTree().Paused;
		GetTree().Paused = isPaused;
		Visible = isPaused;
		if (PauseButton != null)
		{
			PauseButton.Visible = !isPaused;
		}
	}

	private void OnContinuePressed()
	{
		GetTree().Paused = false;
		Visible = false;
		if (PauseButton != null)
		{
			PauseButton.Visible = true;
		}
	}

	private void OnQuitPressed()
	{
		GetTree().Paused = false;
		GetTree().Quit();
	}
}
