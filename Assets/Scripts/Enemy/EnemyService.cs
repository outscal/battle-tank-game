using EnemySO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyServices
{
    public class EnemyService : SingletonGeneric<EnemyService>
    {
        public EnemyScriptanleObjectList enemyList;
        public EnemyView view;

        private void Start()
        {
            CreateNewEnemy();
        }

        private void CreateNewEnemy()
        {
            EnemyScriptableObject enemy = enemyList.enemies[0];
            EnemyModel model = new EnemyModel(enemy);
            EnemyController controller = new EnemyController(model, view);
        }
    }
}
