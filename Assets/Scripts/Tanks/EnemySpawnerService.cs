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
            Transform randomTransform = TankSpawnPositionManager.Instance.GetEmptySpawnPosition();
            EnemyController enemyTank = Instantiate(enemyTankPrefab, randomTransform.position,Quaternion.identity);
            enemyTank.transform.eulerAngles = randomTransform.eulerAngles;
            TankService.Instance.AddTank(enemyTank);
            return enemyTank;
        }
    }
}
