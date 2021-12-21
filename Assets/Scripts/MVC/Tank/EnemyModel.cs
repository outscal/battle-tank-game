using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MVC.Tank
{
    public class EnemyModel
    {
        public EnemyModel(EnemyScriptableObject enemyScriptableObject, BulletScriptableObject bulletScriptableObject)
        {
            TankType = enemyScriptableObject.TankType;
            Speed = enemyScriptableObject.Speed;
            Health = enemyScriptableObject.Health;
            TankName = enemyScriptableObject.TankName;
            ShotDamage = bulletScriptableObject.DamageDealt;
        }

        public TankType TankType { get; }
        public float Speed { get; private set; }
        public float Health { get; private set; }
        public String TankName { get; private set; }
        public float ShotDamage { get; private set; }
    }
}