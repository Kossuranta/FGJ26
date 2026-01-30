using Godot;

public partial class House : Node3D
{
	/// <summary>
	/// Reference to the player spawn point. Set this in the editor.
	/// </summary>
	[Export] public Marker3D Spawnpoint { get; set; }
}
