using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            UIManager.Instance.UpdateGameState(GameState.Game);
            SceneManager.LoadScene(UIManager.Instance.DefaultScriptableObject.gameScene);

        }

        private void HomeBtn()
        {
            UIManager.Instance.UpdateGameState(GameState.MainMenu);
            SceneManager.LoadScene(UIManager.Instance.DefaultScriptableObject.mainScene);
        }

    }
}