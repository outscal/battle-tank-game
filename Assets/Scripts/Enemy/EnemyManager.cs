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

        private List<Vector3> enemiesPosition;

        public List<Vector3> EnemiesPosition{ get { return enemiesPosition; }}

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

            enemiesPosition = new List<Vector3>();
//            enemyDestroyed += DestroyEnemy;
            if (scriptableObjEnemyList == null)
                scriptableObjEnemyList = Resources.Load<ScriptableObjEnemyList>("EnemyListHolder");
        }

        private void Start()
        {
            GameManager.Instance.GameStarted += ResetEnemyList;
            GameManager.Instance.ReplayGame += ResetEnemyList;
            enemiesKilled = SaveLoadManager.Instance.GetEnemiesKilledProgress();
            Debug.Log("[EnemyManager] EnemiesKilled Count " + enemiesKilled);
        }

        void ResetEnemyList()
        {
            enemyList = new List<EnemyController>();
        }

        public void SpawnEnemy(Vector3 position)
        {
            int r = UnityEngine.Random.Range(0, scriptableObjEnemyList.enemyList.Count);


            if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Game)
            {
                enemiesPosition.Add(position);
                Debug.Log("[EnemyManager] EnemyPos Added: " + position);
            }

            enemyController = new EnemyController(scriptableObjEnemyList.enemyList[r], position);
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