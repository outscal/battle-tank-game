using System;
using UnityEditor;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// handling enemy tank model 
    /// </summary>
    public class EnemyTankModel
    {
        private EnemyTankController enemyTankController;
        private EnemyTankScriptableObject EnemyTankScriptableObject;

        public EnemyTankType EnemyTankType { get; private set; }
        public float Speed { get; private set; }
        public int Health { get; set; }

        public float fireRate { get; private set; }

        public BulletScriptableObject bulletForce { get; private set; }

        public BulletScriptableObject bulletType { get; private set; }


        public float patrollingRadius { get; private set; }

        public BoxCollider groundArea;

        public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            this.EnemyTankScriptableObject = enemyTankScriptableObject;
            Speed = enemyTankScriptableObject.Speed;
            Health = enemyTankScriptableObject.Health;
            groundArea = enemyTankScriptableObject.groundArea;
            fireRate = enemyTankScriptableObject.fireRate;
            bulletType = enemyTankScriptableObject.bulletType;
        }

        public void SetEnemyTankController(EnemyTankController _enemyTankController)
        {
            enemyTankController = _enemyTankController;
        }
        //after enemy death distroy model
        internal void DestroyModel()
        {
            enemyTankController = null;
            bulletType = null;
        }
    }
}