using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Manager;
using System;
using Reward;

namespace Player
{
    [System.Serializable]
    public class PositionData
    {
        public int enemyCount;
        public Vector3 position;
    }

    public class PlayerManager : Singleton<PlayerManager>
    {
        public InputComponentScriptableList inputComponentScriptableList;

        public PlayerController playerController { get; private set; }

        private GameObject playerPrefab;

        public event Action playerSpawned;
        public event Action playerDestroyed;

        private Vector3 playerSpawnPos;

        [SerializeField]
        private int maxIteration = 10;

        private int currentIteration = 0;
        private List<PositionData> allPositionData = new List<PositionData>();

        public float safeRadius = 3f;
        public Vector3 safePos { get; private set; }

        private void Start()
        {
            RewardManager.Instance.RewardButtonClicked += SetPlayerPrefab;
        }

        public void SpawnPlayer()
        {
            if(inputComponentScriptableList==null)
            {
                Debug.Log("[PlayerManager] Missing InputComponentScriptableList");
            }

            if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Game)
                GetSafePosition();
            else if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Replay)
            safePos = playerSpawnPos;

            //GetSafePosition();

            //int r = UnityEngine.Random.Range(0, inputComponentScriptableList.inputComponentScriptables.Count);
            playerController = new PlayerController(inputComponentScriptableList.inputComponentScriptables[0],
                                                      safePos, playerPrefab);

            playerSpawned?.Invoke();
   
        }

        public void DestroyPlayer(PlayerController _playerController)
        {
            playerDestroyed?.Invoke();
            _playerController.DestroyPlayer();
            _playerController = null;
        }

        public void GetSafePosition()
        {
            currentIteration++;
            Vector3 pos = RandomPos();
            foreach (Enemy.EnemyController enemy in Enemy.EnemyManager.Instance.EnemyList)
            {
                float distance = Vector3.Distance(pos, enemy.enemyView.transform.position);
                //Debug.Log("[PlayerManager] Distance " + distance);
                if(distance < safeRadius)
                {
                    //if (currentIteration < maxIteration)
                    //{
                    //    GetSafePosition();
                    //}
                    //else
                    //{

                    //}

                    GetSafePosition();
                    return;
                }
            }
            //Debug.Log("[PlayerManager] Player Spawnpos " + pos);
            playerSpawnPos = pos;
            safePos = pos;
            currentIteration = 0;
        }

        public Vector3 RandomPos()
        {
            float x = UnityEngine.Random.Range(-GameManager.Instance.MapSize, GameManager.Instance.MapSize);
            float y = 0;
            float z = UnityEngine.Random.Range(-GameManager.Instance.MapSize, GameManager.Instance.MapSize);

            return new Vector3(x, y, z);
        }

        void SetPlayerPrefab(GameObject PlayerPrefab)
        {
            playerPrefab = PlayerPrefab;
        }

    }
}