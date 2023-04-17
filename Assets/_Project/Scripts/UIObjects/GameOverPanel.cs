using BattleTank.Services;
using UnityEngine;
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
            GameService.Instance.StartGame();
        }
    }
}