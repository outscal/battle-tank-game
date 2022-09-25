using UnityEngine;
using UnityEngine.UI;
using EffectServices;
using UnityEngine.SceneManagement;

namespace UIServices
{
    public class LobbyUIHandler : MonoBehaviour
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
            SpecialEffectService.Instance.Play(SpecialEffectService.Sounds.ButtonClick);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Quit()
        {
            SpecialEffectService.Instance.Play(SpecialEffectService.Sounds.ButtonClick);
            Application.Quit();
        }
    }
}
