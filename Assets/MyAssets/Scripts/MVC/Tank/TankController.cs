using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Service;
using Tank.Model;
using Bullet.Controller;
using Tank.View;
using System;

namespace Tank.Controller
{
	public class TankController
	{
		public TankController(TankModel tankModel, TankView tankPrefab)
		//public TanController(TankModel tankModel, GameObject tankPrefab)
		{
			TankModel = tankModel;

			//GameObject go = GameObject.Instantiate(tankPrefab);
			//TankView = go.GetComponent<TankView>();

			TankView = GameObject.Instantiate<TankView>(tankPrefab);
			TankView.SetController(this);
			TankView.Sethealth(TankModel.Health);
			TankView.SetSpeed(TankModel.Speed);
			TankView.SetTurn(TankModel.Turn);

			Debug.Log("Tank View Created");
		}
		public TankModel TankModel { get; }
		public TankView TankView { get; }
	}
}