using AllServices;
using UnityEngine;
using UIServices;

namespace GameServices
{
    // Handles saved data and pause/resume state of game.
    public class GameHandler : GenericSingleton<GameHandler>
    {
        private void Start()
        {
            EventService.Instance.OnEnemyDeath += CheckForHighScore;
        }

        private void OnDisable()
        {
            EventService.Instance.OnEnemyDeath -= CheckForHighScore;
        }

        // Resets all player prefs data.
        public void ResetData()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        public void CheckForHighScore()
        {
            if (UIHandler.Instance.GetCurrentScore() > GetHighScore())
            {
                PlayerPrefs.SetInt("highScore", UIHandler.Instance.GetCurrentScore());
            }
        }

        public int GetHighScore()
        {
            return PlayerPrefs.GetInt("highScore", 0);
        }
    }
}
