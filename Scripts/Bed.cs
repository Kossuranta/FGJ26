using Godot;

public partial class Bed : StaticBody3D
{
	[Export] public BedArea Area { get; set; }
	[Export] public AnimatedSprite3D WakeUpWarning { get; set; }
	[Export] public AnimatedSprite3D SleepEffect { get; set; }

	public override void _Ready()
	{
		if (Area == null)
		{
			GD.PrintErr("Bed: Area is not assigned! Please assign it in the editor.");
		}

		if (WakeUpWarning == null)
		{
			GD.PrintErr("Bed: WakeUpWarning is not assigned!");
		}

		if (SleepEffect == null)
		{
			GD.PrintErr("Bed: SleepEffect is not assigned!");
		}
	}

	public override void _Process(double delta)
	{
		GameManager gm = GameManager.Instance;
		if (gm == null)
		{
			return;
		}

		bool isSleepFilling = gm.CurrentEvent == MaskType.None || gm.HasCorrectMask();

		if (WakeUpWarning != null)
		{
			WakeUpWarning.Visible = !isSleepFilling;
		}

		if (SleepEffect != null)
		{
			SleepEffect.Visible = isSleepFilling;
		}
	}
}
