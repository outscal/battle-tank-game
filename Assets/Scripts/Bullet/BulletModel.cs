using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletModel
    {
        public BulletModel(Transform spawnTransform, int speed, float tankDamageBooster)
        {
            Speed = speed;
            TankDamageBooster = tankDamageBooster;
            SpawnTransform = spawnTransform;
        }

        public int Speed { get; }
        public float TankDamageBooster { get; }
        public Transform SpawnTransform { get; }
    }
}
