using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Manager;
using System;
using Reward;
using StateMachine;

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

        public List<PlayerController> playerControllerList { get; private set; }

        [SerializeField]
        private int totalPlayers = 1;

        private GameObject playerPrefab;

        public event Action<int> playerSpawned;
        public event Action<int> playerDestroyed;

        private Vector3 playerSpawnPos;

        [SerializeField]
        private int maxIteration = 10;

        private int currentIteration = 0;
        private List<PositionData> allPositionData = new List<PositionData>();

        public float safeRadius = 3f;
        public Vector3 safePos { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            playerControllerList = new List<PlayerController>();
        }

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

            for (int i = 0; i < totalPlayers; i++)
            {
                Debug.Log("[PlayerManager] PlayerSpawned");
                if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Game)
                    GetSafePosition();
                else if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Replay)
                    safePos = playerSpawnPos;

                //GetSafePosition();

                PlayerController playerController = new PlayerController(inputComponentScriptableList.inputComponentScriptables[i],
                                                                         safePos, playerPrefab);
                playerControllerList.Add(playerController);

                playerSpawned?.Invoke(i);
            }
   
        }

        public void DestroyPlayer(PlayerController _playerController)
        {
            playerDestroyed?.Invoke(_playerController.playerID);
            _playerController.DestroyPlayer();
            playerControllerList.RemoveAt(_playerController.playerID);
            _playerController = null;

            if(playerControllerList.Count <= 0)
            {
                GameManager.Instance.UpdateGameState(new GameOverState());
            }

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