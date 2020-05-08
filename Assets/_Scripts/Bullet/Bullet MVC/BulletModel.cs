//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

namespace Bullet.Model
{
    public class BulletModel
    {
        public Vector3 OffsetY { get; private set; }
        public float Speed { get; private set; }
        public float Damage { get; private set; }

        public BulletModel(float speed, float damage, Vector3 offsetY)
        {
            Speed = speed;
            Damage = damage;
            OffsetY = offsetY;
        }

        public void CleanUpAllYourData()
        {
            // clean up all the data.
        }
    }
}