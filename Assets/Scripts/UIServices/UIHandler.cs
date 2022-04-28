using GameplayServices;
using GlobalServices;
using UnityEngine;
using UnityEngine.UI;
using EnemyTankServices;

namespace UIServices
{
    public class UIHandler : MonoSingletonGeneric<UIHandler>
    {

        [SerializeField] private EnemyTankModel tankModel { get; }
        [SerializeField] private Image achievementImage;

        [SerializeField] private Text achievementText;
        [SerializeField] private Text achievementNameText;
        [SerializeField] private Text achievementInfoText;
        [SerializeField] private Text displayText;
        [SerializeField] private Text scoreText;

        public int currentScore;

        private void Start()
        {
            scoreText.text = "Score : " + currentScore.ToString();
        }

        private void increaseScore()
        {
            if (tankModel.b_IsDead == true)
            {
                currentScore += 10;
                scoreText.text = "Score : " + currentScore.ToString();
            }


        }


        public async void ShowAchievementUnlocked(string name, string achievementInfo, float timeForDisplay)
        {
            // GameManager.Instance.PasueGame();
            achievementText.text = "ACHIEVEMENT UNLOCKED";
            achievementNameText.text = name;
            achievementInfoText.text = achievementInfo;
            achievementImage.gameObject.SetActive(true);
            await new WaitForSeconds(timeForDisplay);
            achievementText.text = null;
            achievementNameText.text = null;
            achievementInfoText.text = null;
            achievementImage.gameObject.SetActive(false);
        }

        public async void ShowDisplayText(string text, float timeForDisplay)
        {
            UpdateDisplayText(text);
            displayText.gameObject.SetActive(true);
            await new WaitForSeconds(timeForDisplay);
            displayText.gameObject.SetActive(false);
        }

        public int GetCurrentScore()
        {
            return currentScore;
        }

        public void UpdateScoreText(int scoreMultiplier = 1)
        {
            int finalScore = (currentScore + 10) * scoreMultiplier;
            currentScore = finalScore;
            scoreText.text = "Score : " + finalScore.ToString();
        }

        public void ResetScore()
        {
            currentScore = 0;
            scoreText.text = "Score : " + currentScore.ToString();
        }

        public void UpdateDisplayText(string text)
        {
            displayText.text = text;
        }
    }
}
