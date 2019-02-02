using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;
using UnityEngine.SceneManagement;
using Inputs;

namespace UI
{
    public class GameUI : Instance<GameUI>
    {

        [SerializeField] private Text playerScoreText, playerHealthText;

        private void Start()
        {
            playerScoreText.text = "Player Score " + 0;
        }

        public void UpdatePlayerScore(int value)
        {
            UIManager.Instance.playerScore += value;
            playerScoreText.text = "PlayerScore:" + UIManager.Instance.playerScore;
            if (UIManager.Instance.playerScore > UIManager.Instance.hiScore)
                UIManager.Instance.SetHiScore(UIManager.Instance.playerScore);
        }

        public void UpdatePlayerHealth(int value)
        {
            playerHealthText.text = "PlayerHealth:" + value;
        }

        public void GameOver()
        {
            StartCoroutine(GameOverCoroutine());
        }

        private IEnumerator GameOverCoroutine()
        {
            yield return new WaitForSeconds(1f);
            UIManager.Instance.UpdateGameState(GameState.GameOver);
            SceneManager.LoadScene(UIManager.Instance.DefaultScriptableObject.gameOverScene);
        }  

    }
}