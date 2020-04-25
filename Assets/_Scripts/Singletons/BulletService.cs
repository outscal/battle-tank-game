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
        BulletModel bulletModel;
        BulletController bulletController;

        public BulletController CreateNewBullet(Vector3 position)
        {
            bulletModel = new BulletModel(30f, 10f, new Vector3(0f, 1.6f, 1.35f)); // total health will be 100
            bulletController = new BulletController(bulletModel, BulletView, position);
            return bulletController;
        }

        public void DestroyBullet()
        {
            bulletController.DestroyBulletView();
        }

        public void DestroyControllerAndModel()
        {
            Debug.Log("bullet controller and model destroyed...");
            bulletModel = null;
            bulletController = null;
        }

        public BulletController PleaseGiveMeBullet(Vector3 position)
        {
            BulletController bulletController = CreateNewBullet(position);
            return bulletController;
        }

        //bullet model and controller needs to be destroyed inside the service.
    }
}