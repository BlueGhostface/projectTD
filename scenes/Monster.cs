using Godot;
using System;
using System.Diagnostics;

public partial class Monster : CharacterBody2D
{

	enum WALK_STATE { IDLE, WALK }


	[Export]
	float idletime = 5;
	[Export]
	float walktime = 2;

	private Vector2 direction = Vector2.Zero;
	private Random rand = new Random();

	[Export]
	public float MoveSpeed = 500;

	private WALK_STATE cur_walk_state = WALK_STATE.IDLE;
	private Timer timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		GD.Print("Monster _Ready called!");


		SetPhysicsProcess(true);
		timer = GetNode<Timer>("Timer");
		timer.Timeout += OnTimerTimeout; // <---- This line connects the signal!
		change_walkstate();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public override void _PhysicsProcess(double delta)
	{
		if (cur_walk_state == WALK_STATE.WALK)
        {
            Velocity = direction * MoveSpeed;
        }
        else
        {
            Velocity = Vector2.Zero;
        }

        MoveAndSlide();
	}

	public void change_walkstate()
	{
		Console.WriteLine("outer change_walkstate" + cur_walk_state);

		if (cur_walk_state == WALK_STATE.IDLE)
		{
			cur_walk_state = WALK_STATE.WALK;
			direction = new Vector2(
                (float)(rand.NextDouble() * 2 - 1),
                (float)(rand.NextDouble() * 2 - 1)
            ).Normalized();
			Console.WriteLine("inner change_walkstate" + cur_walk_state);

			timer.Start(walktime);

		}else{
			cur_walk_state = WALK_STATE.IDLE;
            GD.Print("IDLE");
            timer.Start(idletime);
			
		}
	}

	private void OnTimerTimeout()
	{
		change_walkstate();
	}



}


