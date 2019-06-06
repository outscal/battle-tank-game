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

        public bool gamePaused { get; private set; }

        [SerializeField]
        private float mapSize = 30f;

        public event Action GameStarted;
        public event Action GamePaused;
        public event Action GameUnpaused;
        public event Action<int> GamesPlayedAdd;

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

        private void Start()
        {
            GameStarted += SpawnGameElements;

            gamesPlayed = SaveLoadManager.Instance.GetGamesPlayerProgress();

            Debug.Log("[GameManager] GamesPlayed Count " + gamesPlayed);

            //nextScene = DefaultScriptableObject.mainScene.ToString();
            UpdateGameState(new GameLoadingState(defaultScriptableObject.mainScene));
        }

        private void Update()
        {
            if (currentState != null && gamePaused == false)
                currentState.OnUpdate();

            if (Input.GetKeyDown(KeyCode.P))
            {
                if(gamePaused == false)
                {
                    UpdateGameState(new GamePauseState());
                }
                else if (gamePaused == true)
                {
                    InterChangeState(currentState, lastState);
                }

                gamePaused = !gamePaused;
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

            gamesPlayed++;
            GamesPlayedAdd?.Invoke(gamesPlayed);
            for (int i = 0; i < 5; i++)
            {
                Enemy.EnemyManager.Instance.SpawnEnemy();
            }

            Player.PlayerManager.Instance.SpawnPlayer();
        }

    }
}