using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : SingletonGeneric<AchievementSystem>
{
    [SerializeField] private AchievementScriptableObjectList achievementList;
    [SerializeField] private GameObject AchievementPanel;
    [SerializeField] private TextMeshProUGUI AchievementName;
    [SerializeField] private TextMeshProUGUI AchievementInfo;
    private int currentBulletFireLevel;
    private int currentEnemiesDeathLevel;
    private void Start()
    {
        currentBulletFireLevel = 0;
        currentEnemiesDeathLevel = 0;

    }
    public void BulletsFiredCountCheck(int bulletCount)
    {
        for (int i = 0; i < achievementSOList.bulletsFiredAchievementSO.achievements.Length; i++)
        {
            if (i != currentBulletFireLevel) continue;

            if (achievementSOList.bulletsFiredAchievementSO.achievements[i].requirement == bulletCount)
            {
                UnlockAchievement(achievementSOList.bulletsFiredAchievementSO.achievements[i].name, achievementSOList.bulletsFiredAchievementSO.achievements[i].info);
                currentBulletFireLevel = i + 1;
            }
            break;
        }
    }

    public void EnemyDeathCountCheck()
    {
        for (int i = 0; i < achievementSOList.enemiesKilledAchievementSO.achievements.Length; i++)
        {
            if (i != currentEnemiesDeathLevel) continue;

            if (achievementSOList.enemiesKilledAchievementSO.achievements[i].requirement == TankService.Instance.tankController.TankModel.EnemiesKilled)
            {
                UnlockAchievement(achievementSOList.enemiesKilledAchievementSO.achievements[i].name, achievementSOList.enemiesKilledAchievementSO.achievements[i].info);
                currentEnemiesDeathLevel = i + 1;
            }
            break;
        }
    }

    private async void UnlockAchievement(string AchievementName, string AchievementInfo)
    {
        this.AchievementName.text = AchievementName;
        this.AchievementInfo.text = AchievementInfo;
        AchievementPanel.gameObject.SetActive(true);
        await new WaitForSeconds(5);
        AchievementPanel.gameObject.SetActive(false);
    }


    private void OnDisable()
    {
        EventHandler.Instance.OnEnemyDeath -= EnemyDeathCountCheck;
    }
}