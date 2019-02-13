using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using BTScriptableObject;
using UnityEngine.SceneManagement;
using System;
using StateMachine;
using SaveLoad;

namespace BTManager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private DefaultScriptableObject defaultScriptableObject;

        public DefaultScriptableObject DefaultScriptableObject { get { return defaultScriptableObject; } }

        public int gamesPlayed { get; private set; }

        public GameState lastState { get; private set; }
        public GameState currentState { get; private set; }

        public string nextScene { get; private set; }
        public string lastScene { get; private set; }

        //public int frameBeforePause { get; private set; }

        [SerializeField]
        private float mapSize = 30f;

        private int gameplayFrames = 0;

        public int GamePlayFrames { get { return gamesPlayed; } }

        public event Action GameStarted;
        public event Action GamePaused;
        public event Action GameUnpaused;
        public event Action<int> GamesPlayedAdd;
        public event Action ReplayGame;

        public float MapSize
        {
            get { return mapSize; }
        }

        public void OnGameStarted()
        {
            GameStarted?.Invoke();
        }

        public void PauseGame()
        {
            GamePaused?.Invoke();
        }

        public void UnPauseGame()
        {
            GameUnpaused?.Invoke();
        }

        public void OnReplayGame()
        {
            ReplayGame?.Invoke();
        }

        private void Start()
        {
            GameStarted += SpawnGameElements;
            ReplayGame += SpawnGameElements;

            gamesPlayed = SaveLoadManager.Instance.GetGamesPlayerProgress();

            Debug.Log("[GameManager] GamesPlayed Count " + gamesPlayed);

            UpdateGameState(new GameLoadingState(defaultScriptableObject.mainScene));
        }

        private void Update()
        {
            if (currentState != null && currentState.gameStateType != GameStateType.Pause)
            {
                currentState.OnUpdate();
                gameplayFrames++;
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                if(currentState.gameStateType != GameStateType.Pause)
                {
                    UpdateGameState(new GamePauseState());
                    //frameBeforePause = Time.frameCount;
                }
                else if (currentState.gameStateType == GameStateType.Pause)
                {
                    InterChangeState(currentState, lastState);
                }
            }
        }

        public void UpdateGameState(GameState state)
        {
            lastState = currentState;
            if (lastState != null)
                currentState.OnStateExit();

            currentState = state;

            if (currentState != null)
                currentState.OnStateEnter();
        }

        /// <summary>
        /// Inters the state of the change.
        /// </summary>
        /// <param name="stateOne">Current game state</param>
        /// <param name="stateTwo">Last game state.</param>
        void InterChangeState(GameState stateOne, GameState stateTwo)
        {
            this.currentState = stateTwo;
            this.lastState = stateOne;
            lastState.OnStateExit();
        }

        void SpawnGameElements()
        {
            if (currentState.gameStateType == GameStateType.Game)
            {
                gamesPlayed++;
                GamesPlayedAdd?.Invoke(gamesPlayed);
            }

            gameplayFrames = 0;

            for (int i = 0; i < 5; i++)
            {
                if (currentState.gameStateType == GameStateType.Game)
                {
                    Enemy.EnemyManager.Instance.SpawnEnemy(RandomPos());
                }
                else if (currentState.gameStateType == GameStateType.Replay)
                {
                    Vector3 randomPos = Enemy.EnemyManager.Instance.EnemiesPosition[i];
                    Enemy.EnemyManager.Instance.SpawnEnemy(randomPos);
                }

            }

            Player.PlayerManager.Instance.SpawnPlayer();
        }

        Vector3 RandomPos()
        {
            Vector3 randomPos = new Vector3();

            randomPos = new Vector3(UnityEngine.Random.Range(-MapSize, MapSize), 0,
                                                UnityEngine.Random.Range(-MapSize, MapSize));

            return randomPos;
        }
    }
}