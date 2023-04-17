using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BattleTank.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Button restartButton;

        private void Awake()
        {
            restartButton.onClick.AddListener(RestartScene);
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}