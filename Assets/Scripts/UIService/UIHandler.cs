using UnityEngine;
using UnityEngine.UI;
using AllServices;

namespace UIServices
{
    // Handles all UI components from game scene.
    public class UIHandler : GenericSingleton<UIHandler>
    {
        [SerializeField] private GameObject joystickControllerObject;
        [SerializeField] private GameObject buttons;
        [SerializeField] private GameObject gameOverPanel;

        [SerializeField] private Text scoreText;

        private int currentScore;

        private void Start()
        {
            currentScore = 0;

            scoreText.text = "Score : " + currentScore.ToString();
        }

        // Displays unlocked achievemnt text.
        public void ShowAchievementUnlocked(string name, string achievementInfo, float timeForDisplay)
        {
            Debug.Log("Achievement Unlocked");
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

    }
}

