using Godot;

public partial class Salesman : Node3D
{
	[Export] public Node3D Mesh { get; set; }
	[Export] public Node3D StartPosition { get; set; }
	[Export] public Node3D ActivePosition { get; set; }
	[Export] public Node3D EndPosition { get; set; }
	[Export] public float MoveSpeed { get; set; } = 2f;
	[Export] public float ArrivalThreshold { get; set; } = 0.1f;

	private enum State { AtStart, MovingToActive, MovingToEnd, AtEnd }
	private State _currentState = State.AtStart;

	public override void _Ready()
	{
		if (Mesh == null)
		{
			GD.PrintErr("Salesman: Mesh is not assigned!");
		}

		if (StartPosition == null)
		{
			GD.PrintErr("Salesman: StartPosition is not assigned!");
		}

		if (ActivePosition == null)
		{
			GD.PrintErr("Salesman: ActivePosition is not assigned!");
		}

		if (EndPosition == null)
		{
			GD.PrintErr("Salesman: EndPosition is not assigned!");
		}

		// Start at the start position
		if (Mesh != null && StartPosition != null)
		{
			Mesh.GlobalPosition = StartPosition.GlobalPosition;
			Mesh.GlobalRotation = StartPosition.GlobalRotation;
		}

		_currentState = State.AtStart;
	}

	public override void _Process(double delta)
	{
		GameManager gm = GameManager.Instance;
		if (gm == null || Mesh == null || StartPosition == null || ActivePosition == null || EndPosition == null)
		{
			return;
		}

		bool eventActive = gm.CurrentEvent == MaskType.Scary;
		bool maskEquipped = gm.HasCorrectMask();

		UpdateState(eventActive, maskEquipped);
		MoveToTarget((float)delta);
	}

	private void UpdateState(bool eventActive, bool maskEquipped)
	{
		// Reset to start when event ends (from any state except AtStart)
		if (!eventActive && _currentState != State.AtStart)
		{
			Mesh.GlobalPosition = StartPosition.GlobalPosition;
			Mesh.GlobalRotation = StartPosition.GlobalRotation;
			_currentState = State.AtStart;
			return;
		}

		switch (_currentState)
		{
			case State.AtStart:
				if (eventActive)
				{
					_currentState = State.MovingToActive;
				}
				break;

			case State.MovingToActive:
				if (maskEquipped)
				{
					_currentState = State.MovingToEnd;
				}
				break;

			case State.MovingToEnd:
				if (HasReachedTarget(EndPosition))
				{
					_currentState = State.AtEnd;
				}
				break;

			case State.AtEnd:
				// Stay at end until event ends (handled above)
				break;
		}
	}

	private void MoveToTarget(float delta)
	{
		Node3D targetNode = _currentState switch
		{
			State.AtStart => StartPosition,
			State.MovingToActive => ActivePosition,
			State.MovingToEnd => EndPosition,
			State.AtEnd => EndPosition,
			_ => StartPosition
		};

		float t = MoveSpeed * delta;
		Mesh.GlobalPosition = Mesh.GlobalPosition.Lerp(targetNode.GlobalPosition, t);
		Mesh.GlobalRotation = Mesh.GlobalRotation.Lerp(targetNode.GlobalRotation, t);
	}

	private bool HasReachedTarget(Node3D target)
	{
		return Mesh.GlobalPosition.DistanceTo(target.GlobalPosition) < ArrivalThreshold;
	}
}
