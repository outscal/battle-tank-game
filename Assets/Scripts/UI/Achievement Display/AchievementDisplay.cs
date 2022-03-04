using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI.Achievement_Display
{
    public class AchievementDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private void OnEnable()
        {
            Achievement.Achievement.AchievementAccomplished += ShowAchievement;
        }

        private void OnDisable()
        {
            Achievement.Achievement.AchievementAccomplished -= ShowAchievement;
        }

        private void ShowAchievement(Achievement.Achievement achievement)
        {
            StartCoroutine(Display(achievement));
        }

        IEnumerator Display(Achievement.Achievement achievement)
        {
            text.text = achievement.Text();
            text.enabled = true;
            yield return new WaitForSeconds(1.5f);
            text.enabled = false;
        }
    }
}