using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Controller;
using Bullet.View;
using Bullet.Model;
using System;

namespace Bullet.Service
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public BulletView BulletView;

        public BulletController CreateNewBullet(Vector3 position)
        {
            BulletModel bulletModel = new BulletModel(30f, 10f, new Vector3(0f, 1.6f, 0f)); // total health will be 100
            BulletController bulletController = new BulletController(bulletModel, BulletView, position);
            //bulletController.FireBullet(tankRotation); // this statement violates the single responsibility principle.
                                                       //return bulletController;

            return bulletController;
        }

        public void DestroyControllerAndModel()
        {
            Debug.Log("bullet controller and model destroyed...");

            //return true;
        }

        public BulletController PleaseGiveMeBullet(Vector3 position)
        {
            BulletController bulletController = CreateNewBullet(position);
            return bulletController;
        }

        //bullet model and controller needs to be destroyed inside the service.
    }
}