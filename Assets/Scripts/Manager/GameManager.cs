using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using BTScriptableObject;
using UnityEngine.SceneManagement;

namespace BTManager
{
    public enum GameState { MainMenu, Game, GameOver }

    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private DefaultScriptableObject defaultScriptableObject;

        public DefaultScriptableObject DefaultScriptableObject { get { return defaultScriptableObject; } }

        [SerializeField]
        private float mapSize = 30f;

        public float MapSize
        {
            get { return mapSize; }
        }

        private GameState gameState = GameState.MainMenu;

        public GameState GameState { get { return gameState; } }

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
            if (gameState == GameState.Game)
            {
                for (int i = 0; i < 5; i++)
                {
                    Enemy.EnemyManager.Instance.SpawnEnemy();
                }

                Player.PlayerManager.Instance.SpawnPlayer();

            }
        }

        public void UpdateGameState(GameState gameState)
        {
            this.gameState = gameState;
        }
    }
}