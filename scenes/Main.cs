using Godot;
using System;
using System.Reflection.Metadata;

public partial class Main : Node2D
{

	PackedScene scene = GD.Load<PackedScene>("res://scenes/Monster.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Spawn();

	}

	public void Spawn()
    {
		Node2D scene_to_spawn = (Node2D) scene.Instantiate();
		AddChild(scene_to_spawn);
		scene_to_spawn.GlobalPosition = new Vector2(800,500);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
