using GlobalServices;
using UnityEngine;
using EnemyTankServices;
using PlayerTankServices;
using UIServices;

namespace GameplayServices
{
    // Handles saved data and pause/resume state of game.
    public class GameManager : MonoSingletonGeneric<GameManager>
    {
        private void Start()
        {
            EventService.Instance.InvokeOnGameStartedEvent();
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

        // Disables all player and enemy tanks.
        public void PasueGame()
        {
            EventService.Instance.InvokeOnGamePausedEvent();
            PlayerTankService.Instance.TurnOFFTanks();
            EnemyTankService.Instance.TurnOFFEnemies();
        }

        // Enables all player and enemy tanks.
        public void ResumeGame()
        {
            EventService.Instance.InvokeOnGameResumedEvent();
            PlayerTankService.Instance.TurnONTanks();
            EnemyTankService.Instance.TurnONEnemies();
        }

        public void CheckForHighScore()
        {
            if(UIHandler.Instance.GetCurrentScore() > GetHighScore())
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
