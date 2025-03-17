using Godot;
using System;

public partial class Main : Node2D
{

public Marker2D spawnpoint;


    public override void _Ready()
    {
        spawnpoint = GetNode<Marker2D>("SpawnpointA");
        base._Ready();
    }




}
