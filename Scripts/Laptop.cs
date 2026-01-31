using Godot;

public partial class Laptop : Node3D
{
	[Export] public Node3D ScreenRoot { get; set; }
	[Export] public SpotLight3D ScreenLight { get; set; }
	[Export] public Sprite3D ScreenSprite { get; set; }

	[Export] public float MinEnergy { get; set; } = 1f;
	[Export] public float MaxEnergy { get; set; } = 5.0f;
	[Export] public float MinAlpha { get; set; } = 0.3f;
	[Export] public float MaxAlpha { get; set; } = 1.0f;
	[Export] public float FlashInterval { get; set; } = 0.05f;

	private float _flashTimer;
	private RandomNumberGenerator _rng;

	public override void _Ready()
	{
		ValidateExports();
		_rng = new RandomNumberGenerator();
		_rng.Randomize();

		if (ScreenRoot != null)
		{
			ScreenRoot.Visible = false;
		}
	}

	private void ValidateExports()
	{
		if (ScreenRoot == null)
		{
			GD.PrintErr("Laptop: ScreenRoot is not assigned!");
		}

		if (ScreenLight == null)
		{
			GD.PrintErr("Laptop: ScreenLight is not assigned!");
		}

		if (ScreenSprite == null)
		{
			GD.PrintErr("Laptop: ScreenSprite is not assigned!");
		}
	}

	public override void _Process(double delta)
	{
		if (ScreenRoot == null || GameManager.Instance == null)
		{
			return;
		}

		bool shouldBeActive = GameManager.Instance.CurrentEvent == MaskType.FakeEyeGlasses;
		ScreenRoot.Visible = shouldBeActive;

		if (!shouldBeActive)
		{
			return;
		}

		_flashTimer -= (float)delta;
		if (_flashTimer <= 0f)
		{
			_flashTimer = FlashInterval;
			RandomizeScreen();
		}
	}

	private void RandomizeScreen()
	{
		if (ScreenLight != null)
		{
			ScreenLight.LightEnergy = _rng.RandfRange(MinEnergy, MaxEnergy);
		}

		if (ScreenSprite != null)
		{
			Color c = ScreenSprite.Modulate;
			c.A = _rng.RandfRange(MinAlpha, MaxAlpha);
			ScreenSprite.Modulate = c;
		}
	}
}
