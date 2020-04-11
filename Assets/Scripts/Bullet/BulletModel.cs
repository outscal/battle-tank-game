using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletModel
    {
        public BulletModel(Transform spawnTransform, int speed, float bulletDamange)
        {
            Speed = speed;
            BulletDamange = bulletDamange;
            SpawnTransform = spawnTransform;
        }

        public int Speed { get; }
        public float BulletDamange { get; }
        public Transform SpawnTransform { get; }
    }
}
