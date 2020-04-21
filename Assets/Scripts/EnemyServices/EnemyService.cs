using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Commons;
using EnemySO;

namespace EnemyServices
{
    public class EnemyService : GenericSingleton<EnemyService>
    {
        public EnemykScriptableObjectList enemyTypes;
        [HideInInspector] public EnemyScriptableObject enemy;

        private void Start()
        {
            CreateEnemy();
        }

        private void CreateEnemy()
        {
            enemy = enemyTypes.enemies[0];
            EnemyModel enemyModel = new EnemyModel(enemy);
            EnemyController controller = new EnemyController(enemy.enemyView, enemyModel);
        }
    }
}