using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Service;
using Tank.Model;
using Bullet.Service;
using Tank.View;
using Bullet.Model;
using ScriptableObj;

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
			TankModel.SetTankController(this);
			TankView.SetSpeed(TankModel.Speed);
			TankView.SetTurn(TankModel.Turn);
			TankView.Sethealth(TankModel.Health);
		}
		
        public void ShootBullet()
        {
			Debug.Log("shootbullet");
			Bullet_Service.Instance.CreateBullet(TankView.firingLocation.position, TankView.transform.rotation, TankModel.BulletType);
			Debug.Log("shootbullet called");
		}
        public TankView TankView { get; }
		public TankModel TankModel { get; }
	}
}