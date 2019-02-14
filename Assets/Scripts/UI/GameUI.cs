using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;
using UnityEngine.SceneManagement;
using Manager;
using System;
using StateMachine;
using Player;

namespace UI
{
    public class GameUI : Instance<GameUI>
    {

        [SerializeField] private Text playerScoreText, playerHealthText, achievementText;
        [SerializeField] private GameObject gameMenu, replayMenu;
        [SerializeField] private Button exitReplayBtn, speedUpReplayBtn, speedDownReplayBtn;

        public int timeScaleMultiplier { get; private set; }

        //public event Action ScoreIncreased;

        private void OnDisable()
        {
            if (PlayerManager.Instance != null)
                PlayerManager.Instance.playerSpawned -= GetPlayerEvents;
            if (AchievementM.AchievementManager.Instance != null)
                AchievementM.AchievementManager.Instance.AchievementUnlocked -= DisplayAchievement;
        }

        private void OnEnable()
        {
            PlayerManager.Instance.playerSpawned += GetPlayerEvents;
            AchievementM.AchievementManager.Instance.AchievementUnlocked += DisplayAchievement;
        }

        private void Start()
        {
            exitReplayBtn.onClick.AddListener(() => ExitReplay());
            speedUpReplayBtn.onClick.AddListener(() => SpeedUp());
            speedDownReplayBtn.onClick.AddListener(() => SpeedDown());

            if(GameManager.Instance.currentState.gameStateType == GameStateType.Game)
            {
                gameMenu.SetActive(true);
                replayMenu.SetActive(false);
            }
            else if (GameManager.Instance.currentState.gameStateType == GameStateType.Replay)
            {
                gameMenu.SetActive(false);
                replayMenu.SetActive(true);
            }
        }

        void ExitReplay()
        {
            GameManager.Instance.UpdateGameState(new GameOverState());
            SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.gameOverScene);
        }

        void SpeedUp()
        {
            if (timeScaleMultiplier < 4)
            {
                timeScaleMultiplier++;
                Time.timeScale = timeScaleMultiplier;
            }
        }

        void SpeedDown()
        {
            if (timeScaleMultiplier > 1)
            {
                timeScaleMultiplier--;
                Time.timeScale = timeScaleMultiplier;
            }
        }

        void GetPlayerEvents()
        {
            if (PlayerManager.Instance.playerController == null)
                Debug.Log("[GameUI] PlayerController is missing");
            else if (PlayerManager.Instance.playerController != null)
                Debug.Log("[GameUI] PlayerController is present");

            PlayerManager.Instance.playerController.scoreUpdate += UpdatePlayerScore;
            PlayerManager.Instance.playerController.healthUpdate += UpdatePlayerHealth;
            Debug.Log("[GameUI] Player Events Called");
        }

        void UpdatePlayerScore(int value)
        {
            UIManager.Instance.playerScore = value;
            playerScoreText.text = "Player Score:" + UIManager.Instance.playerScore;
            if (UIManager.Instance.playerScore > UIManager.Instance.hiScore)
                UIManager.Instance.SetHiScore(UIManager.Instance.playerScore);

            //ScoreIncreased?.Invoke();
            UIManager.Instance.InvokeScoreIncreasedAction();
            Debug.Log("[GameUI] Score Updated");
        }

        void UpdatePlayerHealth(int value)
        {
            playerHealthText.text = "Player Health:" + value;
            Debug.Log("[GameUI] Health Updated");
        }

        public void GameOver()
        {
            PlayerManager.Instance.playerController.scoreUpdate -= UpdatePlayerScore;
            PlayerManager.Instance.playerController.healthUpdate -= UpdatePlayerHealth;

            StartCoroutine(GameOverCoroutine());
        }

        //public void Respawn(Inputs.InputComponent inputComponent)
        //{
        //    Inputs.InputManager.Instance.RemoveInputComponent(inputComponent);
        //    PlayerManager.Instance.SpawnPlayer();
        //}

        private IEnumerator GameOverCoroutine()
        {
            yield return new WaitForSeconds(1f);
            //GameManager.Instance.UpdateGameState(new GameOverState());
            GameManager.Instance.UpdateGameState(new GameReplayState(GameManager.Instance.DefaultScriptableObject.gameScene));
            SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.gameScene);
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