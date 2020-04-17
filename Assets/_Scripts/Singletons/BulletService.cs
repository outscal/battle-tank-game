using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Controller;
using Bullet.View;
using Bullet.Model;

namespace Bullet.Service
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public BulletView BulletView;

        public void CreateNewBullet(Vector3 position, Vector3 tankRotation)
        {
            BulletModel bulletModel = new BulletModel(30f, 10f, new Vector3(0f, 1.6f, 0f)); // total health will be 100
            BulletController bulletController = new BulletController(bulletModel, BulletView, position);
            bulletController.FireBullet(tankRotation); // this statement violates the single responsibility principle.
                                                       //return bulletController;
        }
    }
}