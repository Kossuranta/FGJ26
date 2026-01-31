using Godot;

public partial class Stove : Node3D
{
	[Export] public AnimatedSprite3D GasAnimation { get; set; }

	public override void _Ready()
	{
		if (GasAnimation == null)
		{
			GD.PrintErr("Stove: GasAnimation is not assigned!");
			return;
		}

		GasAnimation.Visible = false;
	}

	public override void _Process(double delta)
	{
		if (GasAnimation == null || GameManager.Instance == null)
		{
			return;
		}

		GasAnimation.Visible = GameManager.Instance.CurrentEvent == MaskType.Gas;
	}
}
