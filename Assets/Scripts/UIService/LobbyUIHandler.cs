using UnityEngine;
using UnityEngine.UI;
using EffectServices;
using UnityEngine.SceneManagement;

using UnityEditor;

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
            highScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetInt("highscore", 0);
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
            EditorApplication.isPlaying = false;
        }
    }
}
