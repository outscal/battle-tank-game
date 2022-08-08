using GameplayServices;
using GlobalServices;
using UnityEngine;
using UnityEngine.UI;

namespace UIServices
{
    // Handles all UI components from game scene.
    public class UIHandler : MonoSingletonGeneric<UIHandler>
    {
        [SerializeField] private GameObject joystickControllerObject;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject gameOverPanel;

        [SerializeField] private GameObject buttons;
        [SerializeField] private Image achievementImage;

        [SerializeField] private Text achievementText;
        [SerializeField] private Text achievementNameText;
        [SerializeField] private Text achievementInfoText;
        [SerializeField] private Text displayText;
        [SerializeField] private Text scoreText;

        private int currentScore;
        private bool b_IsAchievementVisible;

        private void Start()
        {
            currentScore = 0;

            b_IsAchievementVisible = false;

            scoreText.text = "Score : " + currentScore.ToString();

            EventService.Instance.OnGameOver += GameOver;
            EventService.Instance.OnGamePaused += GamePaused;
            EventService.Instance.OnGameResumed += GameResumed;
        }

        private void OnDisable()
        {
            EventService.Instance.OnGameOver -= GameOver;
            EventService.Instance.OnGamePaused -= GamePaused;
            EventService.Instance.OnGameResumed -= GameResumed;
        }

        // If game pasued, disables all UI components and enables pause menu panel.
        private void GamePaused()
        {
            scoreText.gameObject.SetActive(false);
            joystickControllerObject.SetActive(false);
            buttons.gameObject.SetActive(false);
            pausePanel.gameObject.SetActive(true);
        }

        // If game resumed, enables all UI components and disables pause menu panel.
        private void GameResumed()
        {
            scoreText.gameObject.SetActive(true);
            joystickControllerObject.SetActive(true);
            buttons.gameObject.SetActive(true);
            pausePanel.gameObject.SetActive(false);
        }

        // Displays unlocked achievemnt text.
        public async void ShowAchievementUnlocked(string name, string achievementInfo, float timeForDisplay)
        {
            b_IsAchievementVisible = true;

            GameManager.Instance.PasueGame();

            pausePanel.gameObject.SetActive(false);
            achievementText.text = "ACHIEVEMENT UNLOCKED";
            achievementNameText.text = name;
            achievementInfoText.text = achievementInfo;
            achievementImage.gameObject.SetActive(true);

            await new WaitForSeconds(timeForDisplay);

            achievementImage.gameObject.SetActive(false);
            GameManager.Instance.ResumeGame();

            b_IsAchievementVisible = false;
        }

        // Displays wave number.
        public async void ShowDisplayText(string text, float timeForDisplay)
        {
            if(b_IsAchievementVisible)
            {
                await new WaitForSeconds(timeForDisplay);
            }

            GameManager.Instance.PasueGame();
            pausePanel.gameObject.SetActive(false);

            displayText.text = text;
            displayText.gameObject.SetActive(true);

            await new WaitForSeconds(timeForDisplay);

            displayText.gameObject.SetActive(false);
            GameManager.Instance.ResumeGame();
        }

        // Returns current player score.
        public int GetCurrentScore()
        {
            return currentScore;
        }

        // To set current score value. 
        public void UpdateScoreText(int scoreMultiplier = 1)
        {
            int finalScore = (currentScore + 10) * scoreMultiplier;
            currentScore = finalScore;
            scoreText.text = "Score : " + finalScore.ToString();
        }

        // Enables game over panel.
        public void ShowGameOverUI()
        {
            gameOverPanel.SetActive(true);
            pausePanel.SetActive(false);
            SetGameOverPanelAlpha();
        }

        // Disables all UI components.
        async private void GameOver()
        {
            scoreText.gameObject.SetActive(false);
            joystickControllerObject.SetActive(false);
            buttons.gameObject.SetActive(false);

            await new WaitForSeconds(4.5f);
            ShowGameOverUI();
        }

        // Gradually increases aplha value of background image from 0 to 1.
        async private void SetGameOverPanelAlpha()
        {
            float newAlpha = 0;
            Color panelColor = gameOverPanel.GetComponent<Image>().color;

            while (newAlpha < 1)
            {
                newAlpha += Time.deltaTime;
                newAlpha = Mathf.Min(newAlpha, 1f);

                panelColor.a = newAlpha;
                gameOverPanel.GetComponent<Image>().color = panelColor;

                await new WaitForSeconds(0.0005f);
            }
        }
    }
}

