using Godot;
using System;

public partial class Player : CharacterBody2D
{


	[Export]
	public float movespeed = 200;



	

	

    public override void _PhysicsProcess(double delta)
    {
		var inputDirection = Input.GetVector("left","right","up","down");
		var isoDirection = new Vector2(
			inputDirection.X - inputDirection.Y,
        (inputDirection.X + inputDirection.Y) / 2
    );


		Velocity = isoDirection.Normalized() * movespeed;

		MoveAndSlide();
        base._PhysicsProcess(delta);


    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
