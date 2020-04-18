using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Bullet
{
    public class BulletModel
    {
        public BulletModel(BulletScriptableObject bullet)
        {
            Speed = bullet.bulletSpeed;
          
        }

        public int Speed { get; }
        public float Damage { get; }
    }
}