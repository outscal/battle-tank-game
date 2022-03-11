using AchievementScriptables;
using GlobalServices;
using PlayerTankServices;
using UIServices;
using UnityEngine;

namespace AchievementServices
{
    public class AchievementHandler : MonoSingletonGeneric<AchievementHandler>
    {
        [SerializeField] private AchievementHolder achievementSOList;

        private int currentBulletFiredAchivement;
        private int currentEnemiesKilledAchievement;

        private void Start()
        {
            currentBulletFiredAchivement = PlayerPrefs.GetInt("currentBulletFiredAchivementLevel", 0);
            currentEnemiesKilledAchievement = PlayerPrefs.GetInt("currentEnemiesKilledAchievementLevel", 0);
        }

        public void CheckForBulletFiredAchievement()
        {
            for (int i = 0; i < achievementSOList.bulletsFiredAchievementSO.achievements.Length; i++)
            {
                if (i != currentBulletFiredAchivement) continue;

                if (PlayerTankService.Instance.GetTankController().tankModel.bulletsFired == achievementSOList.bulletsFiredAchievementSO.achievements[i].requirement)
                {
                    UnlockAchievement(achievementSOList.bulletsFiredAchievementSO.achievements[i].name, achievementSOList.bulletsFiredAchievementSO.achievements[i].info);
                    currentBulletFiredAchivement = i + 1;
                    PlayerPrefs.SetInt("currentBulletFiredAchivementLevel", currentBulletFiredAchivement);
                }
                break;
            }
        }

        public void CheckForEnemiesKilledAchievement()
        {
            for (int i = 0; i < achievementSOList.enemiesKilledAchievementSO.achievements.Length; i++)
            {
                if (i != currentEnemiesKilledAchievement) continue;

                if (PlayerTankService.Instance.GetTankController().tankModel.enemiesKilled == achievementSOList.enemiesKilledAchievementSO.achievements[i].requirement)
                {
                    UnlockAchievement(achievementSOList.enemiesKilledAchievementSO.achievements[i].name, achievementSOList.enemiesKilledAchievementSO.achievements[i].info);
                    currentEnemiesKilledAchievement = i + 1;
                    PlayerPrefs.SetInt("currentEnemiesKilledAchievement", currentEnemiesKilledAchievement);
                }
                break;
            }
        }
        private void UnlockAchievement(string achievementName, string achievementInfo)
        {
            UIHandler.Instance.ShowAchievementUnlocked(achievementName, achievementInfo, 3f);
        }

        private void SubscribeEvent()
        {
            EventService.Instance.OnEnemyDeath += UpdateEnemiesKilledCount;
            EventService.Instance.OnplayerFiredBullet += UpdateBulletsFiredCount;
        }

        private void UnsubscribeEvents()
        {
            EventService.Instance.OnEnemyDeath -= UpdateEnemiesKilledCount;
            EventService.Instance.OnplayerFiredBullet -= UpdateBulletsFiredCount;
        }
        private void UpdateBulletsFiredCount()
        {
            PlayerTankService.Instance.GetTankController().tankModel.bulletsFired += 1;
            PlayerPrefs.SetInt("BulletsFired", PlayerTankService.Instance.GetTankController().tankModel.bulletsFired);
            AchievementHandler.Instance.CheckForBulletFiredAchievement();
        }
        private void UpdateEnemiesKilledCount()
        {
            PlayerTankService.Instance.GetTankController().tankModel.enemiesKilled += 1;
            PlayerPrefs.SetInt("EnemiesKilled", PlayerTankService.Instance.GetTankController().tankModel.enemiesKilled);
            UIHandler.Instance.UpdateScoreText();
            AchievementHandler.Instance.CheckForEnemiesKilledAchievement();
        }

    }
}
