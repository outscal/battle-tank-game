using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
	public TankModel(float speed, float turn, float health)
	{
		Speed = speed;
		Turn = turn;
		Health = health;
	}
	public float Speed { get; }
	public float Turn { get; }
	public float Health { get; }
}
