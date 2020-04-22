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
        private List<EnemyController> enemies = new List<EnemyController>();

        private void Start()
        {
            CreateEnemy();
        }

        private void CreateEnemy()
        {
            enemy = enemyTypes.enemies[0];
            EnemyModel enemyModel = new EnemyModel(enemy);
            EnemyController controller = new EnemyController(enemy.enemyView, enemyModel);
            enemies.Add(controller);
        }

        public void DestroyEnemy(EnemyController enemy)
        {
            enemy.DestoryController();

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemy == enemies[i])
                {
                    enemies[i] = null;
                    enemies.Remove(enemies[i]);
                }
            }
        }
    }
}