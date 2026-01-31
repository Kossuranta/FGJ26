using Godot;
using System;

public partial class MinigameSpammer : MinigameBase
{
	[Export]
	public ProgressBar UiObject;

	private Random random;
	
	public float progress = 0.0f;
	private float targetValue = 1.0f;
	public float minProgress = 0.01f;
	public float maxProgress = 0.05f;
	
	public override void _Ready()
	{
		StartMinigame();
	}
	
	public override void StartMinigame()
	{
		random = new Random(GetHashCode());
		base.StartMinigame();
		
		if (UiObject != null)
		{
			UiObject.Visible = true;
			UiObject.Value = 0;
			UiObject.MaxValue = targetValue;
		}
		// TODO: start spawning / enable UI / start timer
	}

	public override void StopMinigame()
	{
		if (UiObject != null)
		{
			UiObject.Visible = false;
		}
		base.StopMinigame();
	}
	
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("interact"))
		{
			HandleInput();
		}
	}

	public override void ResetMinigame()
	{
		// TODO: clear spawned objects / reset counters
	}
	
	public override void HandleInput()
	{
		if (Input.IsActionJustPressed("interact"))
		{
			float randomValue = (float)(random.NextDouble() * (maxProgress - minProgress) + minProgress);
			progress += randomValue;

			if (UiObject != null)
			{
				UiObject.Value = progress;
			}
			if(progress >= targetValue)
			{
				StopMinigame();
			}
		}
	}
}
