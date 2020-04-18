using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Enemy
{
    public class EnemyModel
    {
        public EnemyModel(EnemyScriptableObject enemy )
        {   
            EnemyTankType = enemy.EnemyType;
            EnemyFireRateDelay = enemy.FireRateDelay;
            EnemySpeed = enemy.TankSpeed;
            EnemyRotation = enemy.TankRotationSpeed;
            EnemyHealth = enemy.TankHealth;
            EnemyDamage = enemy.TankDamge;
            EnemyColor = enemy.TankColor;
        }

        public EnemyTankType EnemyTankType { get; }
        public float EnemyFireRateDelay { get; }
        public int EnemySpeed { get; }
        public int EnemyRotation { get; }
        public float EnemyHealth { get; set; }
        public float EnemyDamage { get; }
        public Color EnemyColor { get; }
    }
}
