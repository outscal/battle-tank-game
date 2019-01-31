using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

namespace UI
{
    public class GameUI : Singleton<GameUI>
    {
        [SerializeField] private Text playerScoreText, playerHealthText;

        private int playerScore = 0;

        private void Start()
        {
            UpdatePlayerScore(playerScore);
        }

        public void SetPlayerHealth(int health)
        {
            UpdatePlayerHealth(health);
        }

        public void UpdatePlayerScore(int value)
        {
            playerScore += value;
            playerScoreText.text = "PlayerScore:" + playerScore;
        }

        public void UpdatePlayerHealth(int value)
        {
            playerHealthText.text = "PlayerHealth:" + value;
        }

    }
}