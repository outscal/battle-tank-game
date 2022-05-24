using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : SingletonGeneric<AchievementSystem>
{
    [SerializeField] private AchievementHolder achievementSOList;
    [SerializeField] private CanvasRenderer AchievementPanel;
    [SerializeField] private Text AchievementName;
    [SerializeField] private Text AchievementInfo;
    private int currentBulletFiredAchivementLevel;
    private int currentEnemiesKilledAchievementLevel;

    void Start()
    {
        currentBulletFiredAchivementLevel = 0;
        currentEnemiesKilledAchievementLevel = 0;
        EventHandler.Instance.OnEnemyDeath += EnemyDeathCountCheck;
    }

   
    public void BulletsFiredCountCheck(int bulletCount)
    {
        for (int i = 0; i < achievementSOList.bulletsFiredAchievementSO.achievements.Length; i++)
        {
            if (i != currentBulletFiredAchivementLevel) continue;
            if (achievementSOList.bulletsFiredAchievementSO.achievements[i].requirement == bulletCount)
            {
                //Debug.Log("amitchutiya");
                StartCoroutine(UnlockAchievement(achievementSOList.bulletsFiredAchievementSO.achievements[i].name, achievementSOList.bulletsFiredAchievementSO.achievements[i].info));
                currentBulletFiredAchivementLevel = i + 1;
            }
            break;
        }
    }

    public void EnemyDeathCountCheck()
    {
        for (int i = 0; i < achievementSOList.enemiesKilledAchievementSO.achievements.Length; i++)
        {
            if (i != currentEnemiesKilledAchievementLevel) continue;
            if (achievementSOList.enemiesKilledAchievementSO.achievements[i].requirement == TankService.Instance.tankController.TankModel.EnemiesKilled)
            {
                UnlockAchievement(achievementSOList.enemiesKilledAchievementSO.achievements[i].name, achievementSOList.enemiesKilledAchievementSO.achievements[i].info);
               currentEnemiesKilledAchievementLevel = i + 1;
            }
            break;
        }
    }
    IEnumerator UnlockAchievement(string AchievementName, string AchievementInfo)
    {
        this.AchievementName.text = AchievementName;
        this.AchievementInfo.text = AchievementInfo;
        AchievementPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        AchievementPanel.gameObject.SetActive(false);
    }


    private void OnDisable()
  {
        EventHandler.Instance.OnEnemyDeath -= EnemyDeathCountCheck;
    }

}