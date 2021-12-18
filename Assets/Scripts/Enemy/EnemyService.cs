using EnemySO;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyServices
{
    public class EnemyService : SingletonGeneric<EnemyService>
    {
        public List<EnemyScriptableObject> enemyScriptableObject;
        public List<Transform> enemyPos;
        public List<EnemyController> enemies = new List<EnemyController>();
        public EnemyController enemyController;
        private int count;
        private int enemyCount;

        private void Start()
        {
            enemyCount = enemyScriptableObject.Count;
            for (int i = 0; i < enemyCount; i++)
            {
                count = enemyPos.Count;
                int num = Random.Range(0, count);
                int rand = Random.Range(0, enemyCount);
                CreateNewEnemy(enemyPos[num], rand);
                enemyPos.RemoveAt(num);
            }
        }

        private EnemyController CreateNewEnemy(Transform trans, int rand)
        {
            EnemyView enemyView = enemyScriptableObject[rand].enemyView;
            Vector3 pos = trans.position;
            EnemyModel model = new EnemyModel(enemyScriptableObject[rand]);
            enemyController = new EnemyController(model, enemyView, pos);
            enemies.Add(enemyController);
            return enemyController;
        }

        public void destroyEnemyTank(EnemyController enemyController)
        {
            enemyController.destroyEnemyController();
        }

    }
}
