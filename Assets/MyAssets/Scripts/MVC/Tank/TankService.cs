using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Controller;
using Tank.Model;
using Tank.View;
using System;
using Scriptables;
using Bullet.Controller;
using Bullet.Model;

namespace Tank.Service
{
	public class TankService : MonoSingletonGeneric<TankService>
	{
		public TankView tankView;

		//public TankScriptableObject[] tankConfigurations;
		public TankScriptableObjectList tankList;

		private void Start()
		{
			StartGame();
		}
		public void StartGame()
		{
			for(int i = 0; i < 2; i++)
			{
				CreateTank(i);
			}
		}

		private TankController CreateTank(int index)
		{
			//TankScriptableObject tankScriptableObject = tankConfigurations[2];
			
			TankScriptableObject tankScriptableObject = tankList.tanks[index];
			
			//Debug.Log("Tank Type" + tankScriptableObject.tankName);

			TankModel model = new TankModel(TankType.None, 10f, 200f, 100f);
			TankController tank = new TankController(model, tankView);
			return tank;
		}

        /*public BulletController GetBullet(Vector3 position)
        {
			BulletController bulletController = Bullet_Service.Givebullet(position);
			return bulletController;
        }*/
    }
}