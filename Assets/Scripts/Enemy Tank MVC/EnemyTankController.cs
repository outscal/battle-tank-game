using System.Collections;
using System.Collections.Generic;
using GameServices;
using UnityEngine;

namespace EnemyTankServices
{
    public class EnemyTankController
    {
        public EnemyTankModel enemyTankModel { get; }
        public EnemyTankView enemyTankView { get; }

        public EnemyTankController(EnemyTankModel tankModel, EnemyTankView enemyTankPrefab)
        {
            enemyTankModel = tankModel;

            // Spawns enemy tank at random position.
            Transform tranform = TankSpawnPointService.Instance.GetRandomSpawnPoint();
            enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankPrefab, tranform.position, tranform.rotation);
            enemyTankView.enemyTankController = this;
        }
    }
}
