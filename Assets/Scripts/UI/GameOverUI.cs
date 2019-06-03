using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BTManager;
using StateMachine;

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
            GameManager.Instance.UpdateGameState(new GamePlayState(GameManager.Instance.DefaultScriptableObject.gameScene));
            //SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.gameScene);

        }

        private void HomeBtn()
        {
            GameManager.Instance.UpdateGameState(new GameMenuState(GameManager.Instance.DefaultScriptableObject.mainScene));
            //SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.mainScene);
        }

    }
}