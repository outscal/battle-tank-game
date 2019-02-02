using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            UIManager.Instance.UpdateGameState(GameState.Game);

            SceneManager.LoadScene(UIManager.Instance.DefaultScriptableObject.gameScene);
        }
    }
}