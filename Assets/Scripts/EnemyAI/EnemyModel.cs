using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Enemy
{
    public class EnemyModel
    {
        public EnemyModel(EnemyScriptableObject enemy )
        {
            EnemySpeed = enemy.TankSpeed;
            EnemyRotation = enemy.TankRotationSpeed;
            EnemyHealth = enemy.TankHealth;
            //EnemyDamage = enemy
            EnemyColor = enemy.TankColor;
        }

        public int EnemySpeed { get; }
        public int EnemyRotation { get; }
        public float EnemyHealth { get; }
        public float EnemyDamage { get; }
        public Color EnemyColor { get; }
    }
}
