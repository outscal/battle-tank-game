using UnityEngine;
using EnemyScriptableObjects;

namespace EnemyTankServices
{
    public class EnemyTankModel
    {
        public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            Speed = enemyTankScriptableObject.speed;
            Health = enemyTankScriptableObject.health;
            RotationSpeed = enemyTankScriptableObject.rotationSpeed;
            TankColor = enemyTankScriptableObject.color;
        }

        public float Speed { get; }
        public int Health { get; set; }
        public float RotationSpeed { get; }
        public Color TankColor { get; set; }
    }
}
