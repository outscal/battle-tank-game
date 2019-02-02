using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using BTManager;

public enum EnemyType { Red, Blue, Yellow }

namespace Enemy
{
    public class EnemyManager : Singleton<EnemyManager>
    {
        [SerializeField]
        private int totalEnemies = 5;
        private EnemyType enemyType = EnemyType.Red;

        public EnemyType GetEnemyType { get { return enemyType; }}

        [SerializeField]
        private ScriptableObjEnemyList scriptableObjEnemyList;

        public EnemyController enemyController { get; private set; }

        private List<EnemyController> enemyList;

        public List<EnemyController> EnemyList{ get { return enemyList; }}

        private void Awake()
        {
            enemyList = new List<EnemyController>();

            if (scriptableObjEnemyList == null)
                scriptableObjEnemyList = Resources.Load<ScriptableObjEnemyList>("EnemyListHolder");
        }

        public void SpawnEnemy()
        {
            int r = Random.Range(0, scriptableObjEnemyList.enemyList.Count);

            Vector3 randomPos = new Vector3(Random.Range(-GameManager.Instance.MapSize, GameManager.Instance.MapSize), 0,
                                            Random.Range(-GameManager.Instance.MapSize, GameManager.Instance.MapSize));

            enemyController = new EnemyController(scriptableObjEnemyList.enemyList[r], randomPos);

            enemyList.Add(enemyController);

        }


        public void DestroyEnemy(EnemyController _enemyController)
        {
            _enemyController.DestroyEnemyModel();
            _enemyController = null;
        }








    }
}