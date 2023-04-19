// not implemented in current build
using UnityEngine;
using TMPro;
namespace Tanks.UI
{
    public class LevelOver : MonoBehaviour
    {
        private GameObject GameOverPanel;
        [SerializeField] private GameObject nextButton;
        [SerializeField] private TextMeshProUGUI PanelText;
       private void Start() 
       {
            GameOverPanel = this.gameObject;
       }
       public void LevelComplete()
       {
            PanelText.text = "Level Complete";
            nextButton.SetActive(true);
       }
       public void GameOver()
       {
            PanelText.text = "Game Over";
            nextButton.SetActive(false);
       }
    }
}