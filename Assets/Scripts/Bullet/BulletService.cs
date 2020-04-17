﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;

namespace Bullet
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public BulletView bulletView;
        public Transform BulletParent;

        protected override void Awake()
        {
            base.Awake();
        }


        public BulletConroller GetBullet(Transform bulletTransform, float tankDamageBooster)
        {
            BulletModel bulletmodel = new BulletModel(bulletTransform, 10, tankDamageBooster);
            BulletConroller bulletController = new BulletConroller(bulletmodel, bulletView, BulletParent);
            return bulletController;
        }
    }
}
