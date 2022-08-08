using GameplayServices;
using SFXServices;
using TimerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIServices
{
    // Handles all in-game UI buttons.
    public class UIButtons : MonoBehaviour
    {
        private bool b_IsTimesSlow = false;

        // UI button to resume the game.
        public void Resume()
        {
            SFXHandler.Instance.Play(SFXHandler.Sounds.ButtonClick);
            GameManager.Instance.ResumeGame();
        }

        // UI button to pause the game.
        public void Pause()
        {
            SFXHandler.Instance.Play(SFXHandler.Sounds.ButtonClick);
            GameManager.Instance.PasueGame();
        }

        // UI button to restart the game.
        public void Restart()
        {
            SFXHandler.Instance.Play(SFXHandler.Sounds.ButtonClick);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // UI button to quit the game.
        public void Quit()
        {
            SFXHandler.Instance.Play(SFXHandler.Sounds.ButtonClick);
            Application.Quit();
        }

        // UI button to load lobby scene.
        public void Menu()
        {
            SFXHandler.Instance.Play(SFXHandler.Sounds.ButtonClick);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
