using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using BTScriptableObject;
using UnityEngine.SceneManagement;
using System;
using StateMachine;

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

        [SerializeField]
        private float mapSize = 30f;

        public event Action GameStarted;

        public float MapSize
        {
            get { return mapSize; }
        }

        public void OnGameStarted()
        {
            GameStarted?.Invoke();
        }

        //private void OnEnable()
        //{
        //    SceneManager.sceneLoaded += OnSceneLoaded;
        //}

        //private void OnDisable()
        //{
        //    SceneManager.sceneLoaded -= OnSceneLoaded;
        //}

        //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        //{
        //    if (currentState != null)
        //    {
        //        Debug.Log("[GameManager] " + currentState.gameStateType.ToString());
        //        if (currentState.gameStateType == GameStateType.Game)
        //        {
        //            gamesPlayed++;
        //            PlayerPrefs.SetInt("GamesPlayed", gamesPlayed);
        //            GameStarted?.Invoke();
        //            for (int i = 0; i < 5; i++)
        //            {
        //                Enemy.EnemyManager.Instance.SpawnEnemy();
        //            }

        //            Player.PlayerManager.Instance.SpawnPlayer();

        //        }
        //    }
        //}

        private void Start()
        {
            GameStarted += SpawnGameElements;

            if (PlayerPrefs.HasKey("GamesPlayed"))
                gamesPlayed = PlayerPrefs.GetInt("GamesPlayed");

            //nextScene = DefaultScriptableObject.mainScene.ToString();
            UpdateGameState(new GameLoadingState(defaultScriptableObject.mainScene));
        }

        private void Update()
        {
            if (currentState != null)
                currentState.OnUpdate();
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

        void SpawnGameElements()
        {
            gamesPlayed++;
            PlayerPrefs.SetInt("GamesPlayed", gamesPlayed);
            for (int i = 0; i < 5; i++)
            {
                Enemy.EnemyManager.Instance.SpawnEnemy();
            }

            Player.PlayerManager.Instance.SpawnPlayer();
        }

    }
}