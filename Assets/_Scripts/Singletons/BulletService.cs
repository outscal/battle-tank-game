//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using Bullet.Controller;
using Bullet.View;
using Bullet.Model;
//using System;

namespace Bullet.Service
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public BulletView BulletView;
        BulletModel bulletModel;
        BulletController bulletController;

        public BulletController PleaseGiveMeBullet(Vector3 position, Vector3 tankRotation)
        {
            BulletController bulletController = CreateNewBullet(position, tankRotation);
            return bulletController;
        }

        public BulletController CreateNewBullet(Vector3 position, Vector3 tankRotation)
        {
            float RadTankRotation = (tankRotation.y * Mathf.PI) / 180f;
            bulletModel = new BulletModel(30f, 10f, new Vector3(1.35f * Mathf.Sin(RadTankRotation), 1.6f, 1.35f * Mathf.Cos(RadTankRotation)));
            bulletController = new BulletController(bulletModel, BulletView, position);
            return bulletController;
        }

        public void DestroyControllerAndModel()
        {
            bulletModel = null;
            bulletController = null;
        }
    }
}