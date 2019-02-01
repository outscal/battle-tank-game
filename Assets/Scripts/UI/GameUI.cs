using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;
using UnityEngine.SceneManagement;
using Inputs;

public enum GameState { MainMenu, Game, GameOver }

namespace UI
{
    public class GameUI : Singleton<GameUI>
    {
        [SerializeField] private DefaultScriptableObject defaultScriptableObject;
        [SerializeField] private Text playerScoreText, playerHealthText, hiScoreText, gameOverScoreText;
        [SerializeField] private GameObject gameMenu, mainMenu, gameOverMenu;

        private GameState gameState = GameState.MainMenu;

        public GameState GameState { get { return gameState; }}

        private int playerScore = 0;

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            switch (gameState)
            {
                case GameState.MainMenu:
                    mainMenu.SetActive(true);
                    hiScoreText.text = "HiScore:" + defaultScriptableObject.highScore;
                    break;
                case GameState.Game:
                    mainMenu.SetActive(false);
                    gameMenu.SetActive(true);
                    gameOverMenu.SetActive(false);
                    break;
                case GameState.GameOver:
                    gameMenu.SetActive(false);
                    gameOverMenu.SetActive(true);
                    gameOverScoreText.text = "PlayerScore:" + playerScore;
                    InputManager.Instance.EmptyInputComponentList();
                    StartCoroutine(Respawn());
                    break;
                default:
                    break;
            }
        }

        private void Start()
        {
            hiScoreText.text = "HiScore:" + defaultScriptableObject.highScore;
        }

        public void PlayBtn()
        {
            gameState = GameState.Game;
            SceneManager.LoadScene(defaultScriptableObject.gameScene);
        }

        public void UpdatePlayerScore(int value)
        {
            playerScore += value;
            playerScoreText.text = "PlayerScore:" + playerScore;
            if (playerScore > defaultScriptableObject.highScore)
                defaultScriptableObject.highScore = playerScore;
        }

        public void UpdatePlayerHealth(int value)
        {
            playerHealthText.text = "PlayerHealth:" + value;
        }

        public void GameOver()
        {
            gameState = GameState.GameOver;
            StartCoroutine(GameOverCoroutine());
        }

        private IEnumerator GameOverCoroutine()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(defaultScriptableObject.gameOverScene);
        }  

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(2f);
            gameState = GameState.Game;
            SceneManager.LoadScene(defaultScriptableObject.gameScene);
        }
    }
}