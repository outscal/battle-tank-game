using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public enum EnemyType { Red, Blue, Yellow }

namespace Enemy
{
    public class EnemyManager : Singleton<EnemyManager>
    {
        [SerializeField]
        private int totalEnemies = 5;
        private EnemyType enemyType = EnemyType.Red;

        public EnemyType GetEnemyType { get { return enemyType; }}

        private ScriptableObjEnemyList scriptableObjEnemyList;

        public EnemyController enemyController { get; private set; }

        private void Awake()
        {
            if (scriptableObjEnemyList == null)
                scriptableObjEnemyList = Resources.Load<ScriptableObjEnemyList>("EnemyListHolder");

            for (int i = 0; i < totalEnemies; i++)
            {
                SpawnEnemy();
            }
        }

        public void SpawnEnemy()
        {
            int r = Random.Range(0, scriptableObjEnemyList.enemyList.Count);

            Vector3 randomPos = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));

            enemyController = new EnemyController(scriptableObjEnemyList.enemyList[r], randomPos);

        }


        public void DestroyEnemy(EnemyController _enemyController)
        {
            _enemyController.DestroyEnemyModel();
            _enemyController = null;
        }








    }
}