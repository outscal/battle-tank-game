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
        public int Health { get; private set; }


        public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            this.EnemyTankScriptableObject = enemyTankScriptableObject;
            Speed = enemyTankScriptableObject.Speed;
            Health = enemyTankScriptableObject.Health;
        }


    }
}