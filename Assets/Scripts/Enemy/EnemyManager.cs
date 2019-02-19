using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Manager;
using System;
using SaveLoad;
using UnityEngine.SceneManagement;
using StateMachine;
using Interfaces;
using Audio;

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

    public class EnemyManager : IEnemy
    {
        [SerializeField]
        private int totalEnemies = 5;
        private EnemyType enemyType = EnemyType.Red;

        private int enemiesKilled;

        private List<EnemyData> enemiesData;
        private List<Vector3> enemiesPosition;

        public event Action enemySpawned;
        public event Action<AudioName> DestroyEnemySoundFX;
        public event Action<int> EnemiesKillCount;
        public event Action<Vector3> AlertMode;

        public EnemyType GetEnemyType { get { return enemyType; }}

        [SerializeField]
        private ScriptableObjEnemyList scriptableObjEnemyList;

        public EnemyController enemyController { get; private set; }

        private List<EnemyController> enemyList;

        public event Action<int> EnemyDestroyed;

        private IGameManager gameManager;

        public EnemyManager()
        {
            enemyList = new List<EnemyController>();
            enemiesPosition = new List<Vector3>();
            enemiesData = new List<EnemyData>();
            //            enemyDestroyed += DestroyEnemy;
            if (scriptableObjEnemyList == null)
                scriptableObjEnemyList = Resources.Load<ScriptableObjEnemyList>("EnemyListHolder");

            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

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
            ResetEnemyList();

            if (gameManager.GetCurrentState().gameStateType == GameStateType.Game)
            {
                enemiesData = new List<EnemyData>();
                enemiesPosition = new List<Vector3>();
            }

            for (int i = 0; i < totalEnemies; i++)
            {
                int r = 0;

                if (gameManager.GetCurrentState().gameStateType == GameStateType.Game)
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
                else if (gameManager.GetCurrentState().gameStateType == GameStateType.Replay)
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
            EnemyDestroyed?.Invoke(_enemyController.enemyView.shooterID);
            EnemiesKillCount?.Invoke(enemiesKilled);
            enemyList.Remove(_enemyController);
            _enemyController.RemoveAlertMode();
            _enemyController.DestroyEnemyModel();
            _enemyController = null;
            DestroyEnemySoundFX?.Invoke(AudioName.TankExplosion);
        }

        Vector3 RandomPos()
        {
            Vector3 randomPos = new Vector3();

            randomPos = new Vector3(UnityEngine.Random.Range(-gameManager.GetMapSize(), gameManager.GetMapSize()), 0,
                                    UnityEngine.Random.Range(-gameManager.GetMapSize(), gameManager.GetMapSize()));

            return randomPos;
        }

        public int GetEnemiesKilled()
        {
            return enemiesKilled;
        }

        public void OnUpdate()
        {

        }

        public EnemyData GetEnemyData(int index)
        {
            return enemiesData[index];
        }

        public void SetEnemyData(int index, EnemyData data)
        {
            enemiesData[index] = data;
        }

        public List<EnemyController> GetEnemyControllerList()
        {
            return enemyList;
        }
    }
}