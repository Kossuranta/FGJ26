using Godot;
using System;

public partial class MainMenu : Control
{
	private Button _startButton;
	private Button _quitButton;

	public override void _Ready()
	{
		_startButton = GetNode<Button>("CenterContainer/VBoxContainer/StartButton");
		_quitButton  = GetNode<Button>("CenterContainer/VBoxContainer/QuitButton");
		_startButton.Pressed += OnStartPressed;
		_quitButton.Pressed  += OnQuitPressed;
	}

	private void OnStartPressed()
	{
		// TODO: change to your actual gameplay scene path
		GetTree().ChangeSceneToFile("res://Scenes/game_level.tscn");
	}

	private void OnQuitPressed()
	{
		GetTree().Quit();
	}
}
