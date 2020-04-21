using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;

namespace Bullet
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public List<BulletController> Bullets = new List<BulletController>();
        public BulletView bulletView;
        public Transform BulletParent;

        protected override void Awake()
        {
            base.Awake();
        }


        public BulletController GetBullet(Transform bulletTransform, float tankDamageBooster)
        {
            BulletModel bulletmodel = new BulletModel(bulletTransform, 10, tankDamageBooster);
            BulletController bulletController = new BulletController(bulletmodel, bulletView, BulletParent);
            Bullets.Add(bulletController);
            return bulletController;
        }


        public void DestroyBullet(BulletController bullet)
        {
            bullet.KillBullet();
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i] == bullet)
                {
                    Bullets.Remove(Bullets[i]);
                }
            }
            bullet = null;
        }

    }
}
