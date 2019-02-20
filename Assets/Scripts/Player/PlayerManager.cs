using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Manager;
using System;
using Reward;
using StateMachine;
using UI;
using Interfaces;
using Audio;

namespace Player
{
    [System.Serializable]
    public class PositionData
    {
        public int enemyCount;
        public Vector3 position;
    }

    [System.Serializable]
    public struct PlayerData
    {
        public int playerID;
        public int playerScore;
        public float playerHealth;
    }

    public class PlayerManager : Singleton<PlayerManager>
    {
        public InputComponentScriptableList inputComponentScriptableList;

        public List<PlayerController> playerControllerList { get; private set; }

        [SerializeField]
        private int totalPlayers = 1;

        public int TotalPlayer { get { return totalPlayers; } }

        private GameObject playerPrefab;

        public event Action<PlayerData> playerDataEvent;
        public event Action<int> playerDestroyed;
        public event Action<AudioName> playerDestroyedAudioEvent;

        private List<Vector3> playerSpawnPosList;

        [SerializeField]
        private int maxIteration = 10;

        private int currentIteration = 0;
        private List<PositionData> allPositionData = new List<PositionData>();

        public float safeRadius = 3f;
        public Vector3 safePos { get; private set; }

        private IGameManager gameManager;
        private IReward rewardManager;
        private IInput inputManager;
        private IEnemy enemyManager;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            playerControllerList = new List<PlayerController>();
        }

        private void Start()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            if (rewardManager == null)
                rewardManager = StartService.Instance.GetService<IReward>();

            if (inputManager == null)
                inputManager = StartService.Instance.GetService<IInput>();

            if (enemyManager == null)
                enemyManager = StartService.Instance.GetService<IEnemy>();

            rewardManager.RewardButtonClicked += SetPlayerPrefab;
        }

        public void SpawnPlayer()
        {
            playerControllerList = new List<PlayerController>();
            if (inputComponentScriptableList == null)
            {
                Debug.Log("[PlayerManager] Missing InputComponentScriptableList");
            }

            if(gameManager.GetCurrentState().gameStateType == GameStateType.Game)
            {
                playerSpawnPosList = new List<Vector3>();
            }
            int controlIndex = 0;
            for (int i = 0; i < totalPlayers; i++)
            {
                //Debug.Log("[PlayerManager] PlayerSpawned");
                if (gameManager.GetCurrentState().gameStateType == GameStateType.Game)
                {
                    GetSafePosition();
                }
                else if (gameManager.GetCurrentState().gameStateType == GameStateType.Replay)
                    safePos = playerSpawnPosList[i];

                //GetSafePosition();

                PlayerController playerController = new PlayerController(inputComponentScriptableList.inputComponentScriptables[controlIndex],
                                                                         safePos, playerPrefab, i);
                playerControllerList.Add(playerController);

                playerController.playerDataEvent += CreatePlayerData;
                playerController.SendPlayerData();

                //CreatePlayerData(i, playerController.playerModel.Health, playerController.playerModel.score);
                controlIndex++;
                if (controlIndex >= inputComponentScriptableList.inputComponentScriptables.Count)
                    controlIndex = 0;
            }

        }

        void CreatePlayerData(PlayerData playerData)
        {
            playerDataEvent?.Invoke(playerData);
        }

        public void DestroyPlayer(PlayerController _playerController)
        {
            _playerController.playerDataEvent -= CreatePlayerData;
            inputManager.RemoveInputComponent(_playerController.playerInput);
            playerDestroyed?.Invoke(_playerController.playerID);
            _playerController.DestroyPlayer();
            RemovePlayerController(_playerController);
            _playerController = null;

            if(playerControllerList.Count <= 0)
            {
                gameManager.OnGameOver();
                gameManager.UpdateGameState(new GameOverState());
            }

            playerDestroyedAudioEvent?.Invoke(AudioName.TankExplosion);

        }

        public void RemovePlayerController(PlayerController playerController)
        {
            for (int i = 0; i < playerControllerList.Count; i++)
            {
                if (playerControllerList[i] == playerController)
                {
                    playerControllerList.RemoveAt(i);
                    //Debug.Log("[InputManager] Remove InputComponent at index " + i);
                    break;
                }
            }
        }

        public void GetSafePosition()
        {
            currentIteration++;
            Vector3 pos = RandomPos();
            foreach (Enemy.EnemyController enemy in enemyManager.GetEnemyControllerList())
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
            playerSpawnPosList.Add(pos);
            safePos = pos;
            currentIteration = 0;
        }

        public Vector3 RandomPos()
        {
            float x = UnityEngine.Random.Range(-gameManager.GetMapSize(), gameManager.GetMapSize());
            float y = 0;
            float z = UnityEngine.Random.Range(-gameManager.GetMapSize(), gameManager.GetMapSize());

            return new Vector3(x, y, z);
        }

        void SetPlayerPrefab(GameObject PlayerPrefab)
        {
            playerPrefab = PlayerPrefab;
        }

    }
}