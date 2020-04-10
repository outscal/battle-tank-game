using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Enemy
{
    public class EnemyModel
    {
        public EnemyModel(int enemySpeed, int enemyRotation, float enemyHealth, float enemyDamage, Color enemyColor  )
        {
            EnemySpeed = enemySpeed;
            EnemyRotation = enemyRotation;
            EnemyHealth = enemyHealth;
            EnemyDamage = enemyDamage;
            EnemyColor = enemyColor;
        }

        public int EnemySpeed { get; }
        public int EnemyRotation { get; }
        public float EnemyHealth { get; }
        public float EnemyDamage { get; }
        public Color EnemyColor { get; }
    }
}
