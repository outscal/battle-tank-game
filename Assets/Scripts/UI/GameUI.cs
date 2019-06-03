using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;
using UnityEngine.SceneManagement;
using BTManager;
using System;
using StateMachine;

namespace UI
{
    public class GameUI : Instance<GameUI>
    {

        [SerializeField] private Text playerScoreText, playerHealthText, achievementText;

        public event Action ScoreIncreased;

        private void OnEnable()
        {
            Player.PlayerManager.Instance.playerSpawned += GetPlayerEvents;
            AchievementM.AchievementManager.Instance.AchievementUI += DisplayAchievement;
        }

        void GetPlayerEvents()
        {
            if (Player.PlayerManager.Instance.playerController == null)
                Debug.Log("[GameUI] PlayerController is missing");
            else if (Player.PlayerManager.Instance.playerController != null)
                Debug.Log("[GameUI] PlayerController is present");

            Player.PlayerManager.Instance.playerController.scoreUpdate += UpdatePlayerScore;
            Player.PlayerManager.Instance.playerController.healthUpdate += UpdatePlayerHealth;
            Debug.Log("[GameUI] Player Events Called");
        }

        void UpdatePlayerScore(int value)
        {
            UIManager.Instance.playerScore = value;
            playerScoreText.text = "Player Score:" + UIManager.Instance.playerScore;
            if (UIManager.Instance.playerScore > UIManager.Instance.hiScore)
                UIManager.Instance.SetHiScore(UIManager.Instance.playerScore);

            ScoreIncreased?.Invoke();
            Debug.Log("[GameUI] Score Updated");
        }

        void UpdatePlayerHealth(int value)
        {
            playerHealthText.text = "Player Health:" + value;
            Debug.Log("[GameUI] Health Updated");
        }

        public void GameOver()
        {
            Player.PlayerManager.Instance.playerController.scoreUpdate -= UpdatePlayerScore;
            Player.PlayerManager.Instance.playerController.healthUpdate -= UpdatePlayerHealth;
            StartCoroutine(GameOverCoroutine());
        }

        public void Respawn(Inputs.InputComponent inputComponent)
        {
            Inputs.InputManager.Instance.RemoveInputComponent(inputComponent);
            Player.PlayerManager.Instance.SpawnPlayer();
        }

        private IEnumerator GameOverCoroutine()
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.UpdateGameState(new GameOverState());
            SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.gameOverScene);
        }  

        private void DisplayAchievement(string value)
        {
            achievementText.text = value;
            StartCoroutine(AchievementCoroutine());
        }

        IEnumerator AchievementCoroutine()
        {
            achievementText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            achievementText.gameObject.SetActive(false);
        }

    }
}