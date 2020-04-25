using System;
using System.Collections;
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
        //TankService tankService;
        public TankModel TankModel { get; }
        public TankView TankView { get; }

        public TankController(TankModel tankModel, Dictionary<PlayerTankType, TankView> tankPrefab)
        {
            Debug.Log("tank controller created");
            TankModel = tankModel;
            //TankView = GameObject.Instantiate<TankView>(tankView[(int)TankModel.TankType]); // now here on the basis of what the player has selected as tanktype, need to pass a variable in the tankView array.
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
            //TankService.Instance.FireBullet(position, tankRotation);
            BulletController bulletController = TankService.Instance.GetBullet(position);
            bulletController.FireBullet(tankRotation);
        }
    }

}


