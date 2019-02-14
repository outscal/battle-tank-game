using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Manager;
using StateMachine;
using Common;
using Reward;

namespace UI
{
    public class MainMenuUI : Instance<MainMenuUI>
    {

        [SerializeField]
        private Button playButton;

        [SerializeField]
        private Text hiScoreText;

        [SerializeField]
        private RectTransform unlockScroll;

        // Use this for initialization
        void Start()
        {
            hiScoreText.text = "HiScore: " + UIManager.Instance.hiScore;
            playButton.onClick.AddListener(() => PlayBtn());

            AchievementM.AchievementManager.Instance.AchievmentInitialize();
            RewardManager.Instance.PopulateRewardButtons(unlockScroll);
        }

        private void PlayBtn()
        {
            GameManager.Instance.UpdateGameState(new GamePlayState(GameManager.Instance.DefaultScriptableObject.gameScene));
        }


    }
}