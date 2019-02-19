using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AchievementM;
using Manager;
using StateMachine;
using Common;
using Reward;
using Interfaces;

namespace UI
{
    public class MainMenuUI : Instance<MainMenuUI>
    {

        [SerializeField]
        private Button playButton;

        [SerializeField]
        private Text hiScoreText;

        private IAchievement achievementManager;
        private IGameManager gameManager;

        // Use this for initialization
        void Start()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            hiScoreText.text = "HiScore: " + UIManager.Instance.hiScore;
            playButton.onClick.AddListener(() => PlayBtn());

            if (achievementManager == null)
                achievementManager = StartService.Instance.GetService<IAchievement>();

            achievementManager.AchievmentInitialize(0);
            RewardUI.InstanceClass.PopulateRewardButtons(0);
        }

        private void PlayBtn()
        {
            gameManager.UpdateGameState(new GamePlayState(gameManager.GetDefaultScriptable().gameScene));
        }


    }
}