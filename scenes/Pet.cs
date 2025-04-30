using Godot;
using System;

public partial class Pet : CharacterBody2D
{
	[Export]NodePath Target_path;
	[Export]float target_close_distance = 40;
	[Export]float target_far_distance = 100;
	[Export]float move_speed = 20;

	CharacterBody2D target;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		target = (CharacterBody2D)GetNode(Target_path);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		var to_target = target.Position - Position;
		var direction = to_target.Normalized();

		if (to_target.Length() > target_close_distance)
		{
			Velocity = direction * move_speed;

			// Position += direction * move_speed;
		}
		else
		{
			Velocity = Vector2.Zero;
		}

		MoveAndSlide();

		base._PhysicsProcess(delta);
	}

}
