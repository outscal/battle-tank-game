using AchievementSO;
using GameServices;
using BulletServices;
using AllServices;
using UIServices;
using TankServices;
using UnityEngine;

namespace AchievementServices
{
    // Handles achievement unlocking and all achievement related data.
    public class AchievementHandler : GenericSingleton<AchievementHandler>
    {
        // Reference to achievement scriptable object.
        [SerializeField] private AchievementHolder achievementSOList;

        // Variables to store current achievement level reached.
        private int currentBulletFiredAchivementLevel;
        private int currentEnemiesKilledAchievementLevel;

        private void Start()
        {
            currentBulletFiredAchivementLevel = PlayerPrefs.GetInt("currentBulletFiredAchivementLevel", 0);
            currentEnemiesKilledAchievementLevel = PlayerPrefs.GetInt("currentEnemiesKilledAchievementLevel", 0);
        }

        // Unlocks bullet fire achievements 
        public void CheckBulletFiredAchievement()
        {
            // Loops through all available achievements.
            for (int i = 0; i < achievementSOList.bulletsFiredAchievementSO.achievementType.Length; i++)
            {
                if (i != currentBulletFiredAchivementLevel) continue;

                // Checks if required condition is satisfied to unlock achievement.
                if (TankService.Instance.GetTankController().tankModel.bulletsFired == achievementSOList.bulletsFiredAchievementSO.achievementType[i].requirement)
                {
                    UnlockAchievement(achievementSOList.bulletsFiredAchievementSO.achievementType[i].name, achievementSOList.bulletsFiredAchievementSO.achievementType[i].info);
                    currentBulletFiredAchivementLevel = i + 1;
                    PlayerPrefs.SetInt("currentBulletFiredAchivementLevel", currentBulletFiredAchivementLevel);
                }
                break;
            }
        }

        // Unlocks enemies killed achievements if required condition is satisfied.
        public void CheckForEnemiesKilledAchievement()
        {
            for (int i = 0; i < achievementSOList.enemiesKilledAchievementSO.achievements.Length; i++)
            {
                if (i != currentEnemiesKilledAchievementLevel) continue;

                if (TankService.Instance.GetTankController().tankModel.enemiesKilled == achievementSOList.enemiesKilledAchievementSO.achievements[i].requirement)
                {
                    UnlockAchievement(achievementSOList.enemiesKilledAchievementSO.achievements[i].name, achievementSOList.enemiesKilledAchievementSO.achievements[i].info);
                    currentEnemiesKilledAchievementLevel = i + 1;
                    PlayerPrefs.SetInt("currentEnemiesKilledAchievementLevel", currentEnemiesKilledAchievementLevel);
                }
                break;
            }
        }

        // Displays unlocked achievement.
        private void UnlockAchievement(string achievementName, string achievementInfo)
        {
            UIHandler.Instance.ShowAchievementUnlocked(achievementName, achievementInfo, 3f);
        }
    }
}
