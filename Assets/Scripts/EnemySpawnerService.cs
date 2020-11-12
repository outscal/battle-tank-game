using Singleton;
using UnityEngine;
using System.Collections.Generic;
using Tank;

namespace Enemy
{
    public class EnemySpawnerService : MonoSingletonGeneric<EnemySpawnerService>
    {
        [SerializeField]
        private EnemyController enemyTankPrefab;

        public EnemyController CreateEnemy()
        {
            EnemyController enemyTank = Instantiate(enemyTankPrefab, TankSpawnPositionManager.Instance.GetEmptySpawnPosition(),Quaternion.identity);
            TankService.Instance.AddTank(enemyTank);
            return enemyTank;
        }
    }
}
