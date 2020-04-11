using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public BulletView bulletView;

        protected override void Awake()
        {
            base.Awake();
        }

        public void SpawnBullet(Transform bulletTransform, float bulletDamange)
        {
            BulletModel model = new BulletModel(bulletTransform, 10, bulletDamange);
            BulletConroller tank = new BulletConroller(model, bulletView);
        }
    }
}
