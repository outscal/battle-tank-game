using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BTManager;

namespace UI
{
    public class GameOverUI : MonoBehaviour
    {

        [SerializeField]
        private Button respawnBtn, homeBtn;
        [SerializeField] private Text gameOverScoreText;

        public void Start()
        {
            respawnBtn.onClick.AddListener(() => RespawnBtn());
            homeBtn.onClick.AddListener(() => HomeBtn());
            gameOverScoreText.text = "PlayerScore: " + UIManager.Instance.playerScore;
        }

        private void RespawnBtn()
        {
            GameManager.Instance.UpdateGameState(GameState.Game);
            SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.gameScene);

        }

        private void HomeBtn()
        {
            GameManager.Instance.UpdateGameState(GameState.MainMenu);
            SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.mainScene);
        }

    }
}