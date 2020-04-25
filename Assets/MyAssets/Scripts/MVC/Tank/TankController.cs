using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Service;
using Tank.Model;
using Tank.View;

namespace Tank.Controller
{
	public class TankController
	{
		public TankController(TankModel tankModel, TankView tankPrefab)
		//public TanController(TankModel tankModel, GameObject tankPrefab)
		{
			TankModel = tankModel;

			//GameObject go = GaemObject.Instantiate(tankPrefab);
			//TankView = go.GetComponent<TankView>();

			TankView = GameObject.Instantiate<TankView>(tankPrefab);
			TankView.setController(this);
			TankView.sethealth(TankModel.Health);
			TankView.setSpeed(TankModel.Speed);
			TankView.setTurn(TankModel.Turn);

			Debug.Log("Tank View Created");
		}
		public TankModel TankModel { get; }
		public TankView TankView { get; }
	}
}