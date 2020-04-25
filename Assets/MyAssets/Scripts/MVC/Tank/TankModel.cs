using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Service;
using Tank.Controller;
using Tank.View;

namespace Tank.Model
{
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
}