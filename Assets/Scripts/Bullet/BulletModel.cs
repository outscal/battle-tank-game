using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObj;

namespace Bullet
{
    public class BulletModel
    {
        public BulletModel(Transform spawnTransform, float tankDamageBooster, BulletScriptableObj bulletScriptableObj)
        {
            Speed = bulletScriptableObj.Speed;
            TankDamageBooster = tankDamageBooster;
            SpawnTransform = spawnTransform;
            BulletView = bulletScriptableObj.BulletView;
            MaxDamage = bulletScriptableObj.MaxDamage;
            ExplosionForce = bulletScriptableObj.ExplosionForce;
            MaxLifeTime = bulletScriptableObj.MaxLifeTime;
            ExplosionRadius = bulletScriptableObj.ExplosionRadius;
        }

        public int Speed { get; }
        public float TankDamageBooster { get; }
        public Transform SpawnTransform { get; }
        public BulletView BulletView { get; }
        public float MaxDamage { get; }
        public float ExplosionForce { get; }
        public float MaxLifeTime { get; }
        public float ExplosionRadius { get; }
    }
}
