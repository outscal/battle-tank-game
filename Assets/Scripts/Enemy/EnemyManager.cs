using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using BTManager;
using System;

public enum EnemyType { Red, Blue, Yellow }

namespace Enemy
{
    public class EnemyManager : Singleton<EnemyManager>
    {
        [SerializeField]
        private int totalEnemies = 5;
        private EnemyType enemyType = EnemyType.Red;

        public event Action enemySpawned;
        public event Action destroyEnemy;

        public EnemyType GetEnemyType { get { return enemyType; }}

        [SerializeField]
        private ScriptableObjEnemyList scriptableObjEnemyList;

        public EnemyController enemyController { get; private set; }

        private List<EnemyController> enemyList;

        public List<EnemyController> EnemyList{ get { return enemyList; }}

        public event Action EnemyDestroyed;


        private void Awake()
        {
            enemyList = new List<EnemyController>();
//            enemyDestroyed += DestroyEnemy;
            if (scriptableObjEnemyList == null)
                scriptableObjEnemyList = Resources.Load<ScriptableObjEnemyList>("EnemyListHolder");
        }

        public void SpawnEnemy()
        {
            int r = UnityEngine.Random.Range(0, scriptableObjEnemyList.enemyList.Count);

            Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-GameManager.Instance.MapSize, GameManager.Instance.MapSize), 0,
                                            UnityEngine.Random.Range(-GameManager.Instance.MapSize, GameManager.Instance.MapSize));

            enemyController = new EnemyController(scriptableObjEnemyList.enemyList[r], randomPos);
            enemySpawned?.Invoke();
            enemyList.Add(enemyController);

        }


        public void DestroyEnemy(EnemyController _enemyController)
        {
            EnemyDestroyed?.Invoke();
            enemyList.Remove(_enemyController);
            _enemyController.DestroyEnemyModel();
            _enemyController = null;
        }







    }
}