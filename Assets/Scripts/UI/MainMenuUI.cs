using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BTManager;
using StateMachine;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {

        [SerializeField]
        private Button playButton;

        [SerializeField]
        private Text hiScoreText;

        // Use this for initialization
        void Start()
        {
            hiScoreText.text = "HiScore: " + UIManager.Instance.hiScore;
            playButton.onClick.AddListener(() => PlayBtn());
        }

        private void PlayBtn()
        {
            GameManager.Instance.UpdateGameState(new GamePlayState(GameManager.Instance.DefaultScriptableObject.gameScene));

            //SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.gameScene);
        }
    }
}