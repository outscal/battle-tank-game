using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using TankServices;

namespace BulletServices
{
    public class BulletService : GenericSingleton<BulletService>
    {
        public BulletView bulletView;

        public float bulletDamage;
        public float bulletSpeed;


        public void CreateBullet(TankController tank)
        {
            BulletModel bulletModel = new BulletModel(bulletSpeed, bulletDamage);
            BulletController bulletController = new BulletController(bulletView, bulletModel, tank);

        }

    }
}
