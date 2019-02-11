using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using BTManager;
using System;
using SaveLoad;

public enum EnemyType { Red, Blue, Yellow }

namespace Enemy
{
    public class EnemyManager : Singleton<EnemyManager>
    {
        [SerializeField]
        private int totalEnemies = 5;
        private EnemyType enemyType = EnemyType.Red;

        public int enemiesKilled { get; private set; }

        public event Action enemySpawned;
        public event Action destroyEnemy;
        public event Action<int> EnemiesKillCount;

        public EnemyType GetEnemyType { get { return enemyType; }}

        [SerializeField]
        private ScriptableObjEnemyList scriptableObjEnemyList;

        public EnemyController enemyController { get; private set; }

        private List<EnemyController> enemyList;

        public List<EnemyController> EnemyList{ get { return enemyList; }}

        public event Action EnemyDestroyed;


        protected override void Awake()
        {
            base.Awake();

            enemyList = new List<EnemyController>();
//            enemyDestroyed += DestroyEnemy;
            if (scriptableObjEnemyList == null)
                scriptableObjEnemyList = Resources.Load<ScriptableObjEnemyList>("EnemyListHolder");
        }

        private void Start()
        {
            enemiesKilled = SaveLoadManager.Instance.GetEnemiesKilledProgress();
            Debug.Log("[EnemyManager] EnemiesKilled Count " + enemiesKilled);
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
            enemiesKilled++;
            EnemyDestroyed?.Invoke();
            EnemiesKillCount?.Invoke(enemiesKilled);
            enemyList.Remove(_enemyController);
            _enemyController.DestroyEnemyModel();
            _enemyController = null;
        }







    }
}