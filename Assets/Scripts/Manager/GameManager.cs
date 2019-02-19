using UnityEngine;
using Common;
using BTScriptableObject;
using System;
using StateMachine;
using SaveLoad;
using Interfaces;
using Enemy;

namespace Manager
{
    public class GameManager : IGameManager
    {
        private DefaultScriptableObject defaultScriptableObject;

        private int gamesPlayed;

        GameState lastState = new GameState();
        GameState currentState = new GameState();

        string nextScene;
        string lastScene;

        float mapSize = 30f;

        int gameplayFrames = 0;

        public event Action GameStarted;
        public event Action GamePaused;
        public event Action GameUnpaused;
        public event Action<int> GamesPlayedAdd;
        public event Action ReplayGame;

        private IEnemy enemyManager;

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

        public GameManager()
        {
            defaultScriptableObject = Resources.Load<DefaultScriptableObject>("DefaultData");

            GameStarted += SpawnGameElements;
            ReplayGame += SpawnGameElements;
            currentState = new GameState();
            currentState.gameStateType = GameStateType.Loading;

            Debug.Log("[GameManager] CurrentState:" + currentState.gameStateType);

            gamesPlayed = SaveLoadManager.Instance.GetGamesPlayerProgress();

            Debug.Log("[GameManager] GamesPlayed Count " + gamesPlayed);

            UpdateGameState(new GameLoadingState(defaultScriptableObject.mainScene));
        }

        public void OnUpdate()
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
        public void InterChangeState(GameState stateOne, GameState stateTwo)
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

            if (enemyManager == null)
                enemyManager = StartService.Instance.GetService<IEnemy>();

            enemyManager.SpawnEnemy();
        }

        public int GetGamesPlayed()
        {
            return gamesPlayed;
        }

        public string GetNextScene()
        {
            return nextScene;
        }

        public string GetLastScene()
        {
            return lastScene;
        }

        public float GetMapSize()
        {
            return mapSize;
        }

        public int GetGamesFrame()
        {
            return gameplayFrames;
        }

        public GameState GetCurrentState()
        {
            return currentState;
        }

        public GameState GetLastState()
        {
            return lastState;
        }

        public DefaultScriptableObject GetDefaultScriptable()
        {
            return defaultScriptableObject;
        }
    }
}