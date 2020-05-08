//using System;
//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Service;
using Tank.View;
using Tank.Model;
using Bullet.Controller;

namespace Tank.Controller
{
    public class TankController
    {
        public TankModel TankModel { get; }
        public TankView TankView { get; }

        BulletController bulletController;

        //constructor
        public TankController(TankModel tankModel, Dictionary<PlayerTankType, TankView> tankPrefab) 
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab[TankModel.TankType]);
            TankView.SetTankController(this);
        }

        public Vector3 MoveTank(float horizontal, float vertical, Vector3 position)
        {
            position.x += horizontal * TankModel.Speed * Time.deltaTime;
            position.z += vertical * TankModel.Speed * Time.deltaTime;
            return position;
        }

        public float GetTargetRotation(float horizontal, float vertical)
        {
            Vector2 inputDir = (new Vector2(horizontal, vertical)).normalized;
            float targetRotation;
            targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            return targetRotation;
        }

        public void FireBullet(Vector3 position, Vector3 tankRotation)
        {
            bulletController = TankService.Instance.GetBullet(position, tankRotation);
            bulletController.FireBullet(tankRotation);
        }

        public void DestroyTank()
        {
            TankView.InstantiateTankExplosionParticleEffect();
            TankView.DestroyTankPrefab();
            TankModel.ClearUpAllYourData();
            TankService.Instance.DestroyControllerAndModel();
            TankService.Instance.DestroyAllEnemies();
        }
    }

}


