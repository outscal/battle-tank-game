using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Manager;
using System;
using SaveLoad;
using UnityEngine.SceneManagement;
using StateMachine;

public enum EnemyType { Red, Blue, Yellow }

namespace Enemy
{
    [System.Serializable]
    public struct EnemyData
    {
        public Vector3 enemySpawnPos;
        public int enemyType;
        public List<Vector3> wayPoints;
    }

    public class EnemyManager : Singleton<EnemyManager>
    {
        [SerializeField]
        private int totalEnemies = 5;
        private EnemyType enemyType = EnemyType.Red;

        public int enemiesKilled { get; private set; }

        private List<EnemyData> enemiesData;
        private List<Vector3> enemiesPosition;

        public List<EnemyData> EnemyDatas { get { return enemiesData; } }

        public event Action enemySpawned;
        public event Action destroyEnemy;
        public event Action<int> EnemiesKillCount;
        public event Action<Vector3> AlertMode;

        public EnemyType GetEnemyType { get { return enemyType; }}

        [SerializeField]
        private ScriptableObjEnemyList scriptableObjEnemyList;

        public EnemyController enemyController { get; private set; }

        private List<EnemyController> enemyList;

        public List<EnemyController> EnemyList{ get { return enemyList; }}

        public event Action EnemyDestroyed;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.LogWarning("[EnemyManager] Enemy List Count:" + enemyList.Count);
            ResetEnemyList();
        }


        protected override void Awake()
        {
            base.Awake();
            enemyList = new List<EnemyController>();
            enemiesPosition = new List<Vector3>();
            enemiesData = new List<EnemyData>();
//            enemyDestroyed += DestroyEnemy;
            if (scriptableObjEnemyList == null)
                scriptableObjEnemyList = Resources.Load<ScriptableObjEnemyList>("EnemyListHolder");
        }

        private void Start()
        {
            //GameManager.Instance.GameStarted += ResetEnemyList;
            //GameManager.Instance.ReplayGame += ResetEnemyList;
            enemiesKilled = SaveLoadManager.Instance.GetEnemiesKilledProgress();
            Debug.Log("[EnemyManager] EnemiesKilled Count " + enemiesKilled);
        }

        public void AlertEnemies(Vector3 position)
        {
            AlertMode.Invoke(position);
        }

        void ResetEnemyList()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].RemoveAlertMode();
            }

            enemyList = new List<EnemyController>();
        }

        public void SpawnEnemy()
        {
            if (GameManager.Instance.currentState.gameStateType == GameStateType.Game)
            {
                enemiesData = new List<EnemyData>();
                enemiesPosition = new List<Vector3>();
            }

            for (int i = 0; i < totalEnemies; i++)
            {
                int r = 0;

                if (GameManager.Instance.currentState.gameStateType == GameStateType.Game)
                {
                    Vector3 position = RandomPos();
                    r = UnityEngine.Random.Range(0, scriptableObjEnemyList.enemyList.Count);
                    //enemiesPosition.Add(position);

                    EnemyData enemyData = new EnemyData();
                    enemyData.enemySpawnPos = position;
                    enemyData.enemyType = r;
                    enemyData.wayPoints = new List<Vector3>();

                    enemiesData.Add(enemyData);

                    enemyController = new EnemyController(scriptableObjEnemyList.enemyList[r], position, i);
                    enemySpawned?.Invoke();
                    enemyList.Add(enemyController);
                }
                else if (GameManager.Instance.currentState.gameStateType == GameStateType.Replay)
                {
                    Vector3 randomPos = enemiesData[i].enemySpawnPos;
                    r = enemiesData[i].enemyType;

                    enemyController = new EnemyController(scriptableObjEnemyList.enemyList[r], randomPos, i);
                    enemySpawned?.Invoke();
                    enemyList.Add(enemyController);
                    //Enemy.EnemyManager.Instance.SpawnEnemy();
                }
            }

            Player.PlayerManager.Instance.SpawnPlayer();
        }


        public void DestroyEnemy(EnemyController _enemyController)
        {
            enemiesKilled++;
            EnemyDestroyed?.Invoke();
            EnemiesKillCount?.Invoke(enemiesKilled);
            enemyList.Remove(_enemyController);
            _enemyController.RemoveAlertMode();
            _enemyController.DestroyEnemyModel();
            _enemyController = null;
        }

        Vector3 RandomPos()
        {
            Vector3 randomPos = new Vector3();

            randomPos = new Vector3(UnityEngine.Random.Range(-GameManager.Instance.MapSize, GameManager.Instance.MapSize), 0,
                                                UnityEngine.Random.Range(-GameManager.Instance.MapSize, GameManager.Instance.MapSize));

            return randomPos;
        }





    }
}