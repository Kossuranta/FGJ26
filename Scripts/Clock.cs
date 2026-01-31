using Godot;

public partial class Clock : Node
{
	[Export] public Label3D TimeLabel { get; set; }

	[Export] public int StartHour { get; set; } = 22;
	[Export] public int StartMinute { get; set; } = 0;
	[Export] public int EndHour { get; set; } = 7;
	[Export] public int EndMinute { get; set; } = 0;

	private string _lastText;

	public override void _Ready()
	{
		if (TimeLabel == null)
		{
			GD.PrintErr("Clock: TimeLabel is not assigned!");
		}
	}

	public override void _Process(double delta)
	{
		GameManager gm = GameManager.Instance;
		if (gm == null || TimeLabel == null)
		{
			return;
		}

		float t = Mathf.Clamp(gm.NightProgress, 0.0f, 1.0f);
		string text = FormatTime24h(t);

		if (text == _lastText)
		{
			return;
		}

		_lastText = text;
		TimeLabel.Text = text;
	}

	private string FormatTime24h(float progress01)
	{
		int startMinutes = Mathf.Clamp(StartHour, 0, 23) * 60 + Mathf.Clamp(StartMinute, 0, 59);
		int endMinutes = Mathf.Clamp(EndHour, 0, 23) * 60 + Mathf.Clamp(EndMinute, 0, 59);

		int spanMinutes = endMinutes >= startMinutes
			? (endMinutes - startMinutes)
			: ((24 * 60) - startMinutes + endMinutes);

		int currentMinutes = startMinutes + Mathf.RoundToInt(progress01 * spanMinutes);
		currentMinutes %= (24 * 60);

		int hour = currentMinutes / 60;
		int minute = currentMinutes % 60;
		return $"{hour:00}:{minute:00}";
	}
}

