using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Manager;
using StateMachine;
using Interfaces;

namespace UI
{
    public class GameOverUI : MonoBehaviour
    {

        [SerializeField]
        private Button respawnBtn, homeBtn;
        [SerializeField] private Text gameOverScoreText;
        private IGameManager gameManager;

        public void Start()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            respawnBtn.onClick.AddListener(() => RespawnBtn());
            homeBtn.onClick.AddListener(() => HomeBtn());
            gameOverScoreText.text = "PlayerScore: " + UIManager.Instance.playerScore;
        }

        private void RespawnBtn()
        {
            gameManager.UpdateGameState(new GamePlayState(gameManager.GetDefaultScriptable().gameScene));

        }

        private void HomeBtn()
        {
            gameManager.UpdateGameState(new GameMenuState(gameManager.GetDefaultScriptable().mainScene));
        }

    }
}