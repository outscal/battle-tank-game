using BattleTank.GenericSingleton;
using UnityEngine;
using UnityEngine.UI;

namespace BattleTank.Services
{
    public class ScoreService : GenericSingleton<ScoreService>
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private int tankDestroyed;
        private int score;

        public void ResetScore()
        {
            score = 0;
            RefreshUI();
        }

        public void UpdateScore(int _score)
        {
            score += _score;
            RefreshUI();
        }

        public void UpdateTankDestroyedScore()
        {
            score += tankDestroyed;
            RefreshUI();
        }

        private void RefreshUI()
        {
            scoreText.text = "" + score;
        }
    }
}