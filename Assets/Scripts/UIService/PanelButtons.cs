using EffectServices;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace UIServices
{
    public class PanelButtons : MonoBehaviour
    {

        // UI button to restart the game.
        public void Restart()
        {
            SpecialEffectService.Instance.Play(SpecialEffectService.Sounds.ButtonClick);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // UI button to quit the game.
        public void Quit()
        {
            SpecialEffectService.Instance.Play(SpecialEffectService.Sounds.ButtonClick);
            Application.Quit();
        }

        // UI button to load lobby scene.
        public void Menu()
        {
            SpecialEffectService.Instance.Play(SpecialEffectService.Sounds.ButtonClick);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}