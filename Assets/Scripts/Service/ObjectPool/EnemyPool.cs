using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Service;
namespace Tanks.ObjectPool
{
    public class EnemyPool : ObjectPool<EnemyController>
    {
        private EnemyView enemyPrefab;
        private EnemyModel enemyModel;
        private Vector3[] Spawn;
        public EnemyController GetTank(EnemyTankObject enemy)
        {
            enemyModel = new EnemyModel(enemy);
            enemyPrefab = enemy.enemyView;
            Spawn = enemy.PatrolPoints;
            return GetItem();
        }
        protected override EnemyController CreateItem()
        {
            EnemyController enemyController = new EnemyController(enemyModel, enemyPrefab, Spawn);
            return enemyController;
        }
    }
}

