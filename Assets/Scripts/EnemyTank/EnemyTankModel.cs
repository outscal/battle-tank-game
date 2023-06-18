using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyTankModel
    {
        public float EnemyHealth;
        public float WalkPointRange;
        public float sightRange;
        public LayerMask GroundLayerMask;
        public LayerMask PlayerLayerMask;
        public EnemyTankType EnemyTankType;

        public EnemyTankController EnemyTankController { get; private set; }

        public void SetEnemyTankController(EnemyTankController enemyTankController)
        {
            EnemyTankController = enemyTankController;
        }

        public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            EnemyTankType = enemyTankScriptableObject.EnemyTankType;
            EnemyHealth = enemyTankScriptableObject.EnemyHealth;
            WalkPointRange = enemyTankScriptableObject.WalkPointRange;
            sightRange = enemyTankScriptableObject.sightRange;
            GroundLayerMask = enemyTankScriptableObject.GroundLayerMask;
            PlayerLayerMask = enemyTankScriptableObject.PlayerLayerMask;
        }
    }
}