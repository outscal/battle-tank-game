using BattleTank.GenericSingleton;
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

        private Coroutine coroutine;
        private Queue<string> titleQueue;
        private Queue<string> descriptionQueue;

        private float achievementPanelDisplayTime;

        private void Start()
        {
            titleQueue = new Queue<string>();
            descriptionQueue = new Queue<string>();
            achievementPanelDisplayTime = 2f;
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
                yield return new WaitForSeconds(achievementPanelDisplayTime);
                achievementPanel.SetActive(false);
            }
            coroutine = null;
        }
    }
}