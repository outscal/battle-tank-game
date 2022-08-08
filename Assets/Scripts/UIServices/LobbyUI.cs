using GameplayServices;
using SFXServices;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIServices
{
    // Handles all functionality related to lobby UI.
    public class LobbyUI : MonoBehaviour
    {
        public Image backgroundImage;
        public GameObject buttons;
        public Text highScoreText;

        // Displays high score in lobby.
        private void Start()
        {
            highScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetInt("highScore", 0);
        }

        // Loads game scene.
        public void Play()
        {
            SFXHandler.Instance.Play(SFXHandler.Sounds.ButtonClick);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Quit()
        {
            SFXHandler.Instance.Play(SFXHandler.Sounds.ButtonClick);
            Application.Quit();
        }
    }
}
