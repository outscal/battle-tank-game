using BattleTank.GenericSingleton;
using BattleTank.UI;
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

        private Coroutine coroutine;
        private Queue<string> titleQueue;
        private Queue<string> descriptionQueue;

        private float achievementPanelDisplayTime;
        private float coroutineEndTime;

        private void Start()
        {
            titleQueue = new Queue<string>();
            descriptionQueue = new Queue<string>();
            achievementPanelDisplayTime = 5f;
            coroutineEndTime = 2f;
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
    }
}