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
            Debug.Log("enemypool getTank");
            enemyModel = new EnemyModel(enemy);
            enemyPrefab = enemy.enemyView;
            Spawn = enemy.PatrolPoints;
            return GetItem();
        }
        protected override EnemyController CreateItem()
        {
            Debug.Log("enemypool createItem");
            EnemyController enemyController = new EnemyController(enemyModel, enemyPrefab, Spawn);
            return enemyController;
        }
    }
}

