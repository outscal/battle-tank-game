using BattleTank.GenericSingleton;
using BattleTank.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleTank.Services
{
    public class UIService : GenericSingleton<UIService>
    {
        [SerializeField] private GameObject achievementPanel;
        [SerializeField] private Text titleText;
        [SerializeField] private Text descriptionText;
        [SerializeField] private AchievementUIPanel achievementUIPanel;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject healthBarPanel;
        [SerializeField] private GameObject scorePanel;
        [SerializeField] private GameObject tankSelectionUI;
        [SerializeField] private Button infoButton;
        [SerializeField] private Button backButton;
        [SerializeField] private GameObject infoPanel;
        [SerializeField] private float pauseTime;
        [SerializeField] private float resumeTime;
        public PlayerHealthUI PlayerHealthUI;

        private Coroutine coroutine;
        private Queue<string> titleQueue;
        private Queue<string> descriptionQueue;

        [SerializeField] private float achievementPanelDisplayTime;
        [SerializeField] private float coroutineEndTime;

        protected override void Awake()
        {
            base.Awake();
            infoButton.onClick.AddListener(DisplayInfoPanel);
            backButton.onClick.AddListener(CloseInfoPanel);
        }
        
        private void Start()
        {
            titleQueue = new Queue<string>();
            descriptionQueue = new Queue<string>();
        }

        private void DisplayInfoPanel()
        {
            infoPanel.SetActive(true);
            Time.timeScale = pauseTime;
        }

        private void CloseInfoPanel()
        {
            infoPanel.SetActive(false);
            Time.timeScale = resumeTime;
        }

        public void DisplayAchievement(string title, string description)
        {
            titleQueue.Enqueue(title);
            descriptionQueue.Enqueue(description);
            if(coroutine == null)
            {
                coroutine = StartCoroutine(DisplayPanel());
            }
        }

        IEnumerator DisplayPanel()
        {
            while (titleQueue.Count > 0 && descriptionQueue.Count > 0)
            {
                titleText.text = titleQueue.Dequeue();
                descriptionText.text = descriptionQueue.Dequeue();
                achievementPanel.SetActive(true);
                achievementUIPanel.StartIntro(true);

                yield return new WaitForSeconds(achievementPanelDisplayTime);
                achievementUIPanel.StartOutro(true);

                yield return new WaitForSeconds(coroutineEndTime);
                achievementPanel.SetActive(false);
            }
            coroutine = null;
        }

        public void ActivateGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }

        public void DeactivateGameOverPanel()
        {
            gameOverPanel.SetActive(false);
        }

        public void ActivateStartingUI()
        {
            healthBarPanel.SetActive(true);
            scorePanel.SetActive(true);
        }

        public void DeactivateStartingUI()
        {
            healthBarPanel.SetActive(false);
            scorePanel.SetActive(false);
        }

        public void SetPlayerHealthUI()
        {
            PlayerHealthUI.SetPlayerHealthValueUI();
        }

        public void SetTankSelectionUI()
        {
            tankSelectionUI.SetActive(true);
        }
    }
}