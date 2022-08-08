using AchievementSO;
using GlobalServices;
using PlayerTankServices;
using UIServices;
using UnityEngine;

namespace AchievementServices
{
    // Handles achievement unlocking and all achievement related data.
    public class AchievementHandler : MonoSingletonGeneric<AchievementHandler>
    {
        // Reference to achievement scriptable object.
        [SerializeField] private AchievementHolder achievementSOList;

        // Variables to store current achievement level reached.
        private int currentBulletFiredAchivementLevel;
        private int currentEnemiesKilledAchievementLevel;
        private int currentWavesSurvivedAchievementLevel;

        private void Start()
        {
            currentBulletFiredAchivementLevel = PlayerPrefs.GetInt("currentBulletFiredAchivementLevel", 0);
            currentEnemiesKilledAchievementLevel = PlayerPrefs.GetInt("currentEnemiesKilledAchievementLevel", 0);
            currentWavesSurvivedAchievementLevel = PlayerPrefs.GetInt("currentWavesSurvivedAchievementLevel", 0);
        }

        // Unlocks bullet fire achievements if required condition is satisfied.
        public void CheckForBulletFiredAchievement()
        {
            // Loops through all available achievements.
            for(int i=0; i < achievementSOList.bulletsFiredAchievementSO.achievements.Length; i++)
            {
                if (i != currentBulletFiredAchivementLevel) continue;

                // Checks if required condition is satisfied to unlock achievement.
                if(PlayerTankService.Instance.GetTankController().tankModel.bulletsFired == achievementSOList.bulletsFiredAchievementSO.achievements[i].requirement)
                {
                    UnlockAchievement(achievementSOList.bulletsFiredAchievementSO.achievements[i].name, achievementSOList.bulletsFiredAchievementSO.achievements[i].info);
                    currentBulletFiredAchivementLevel = i + 1;
                    PlayerPrefs.SetInt("currentBulletFiredAchivementLevel", currentBulletFiredAchivementLevel);
                }
                break;
            }
        }

        // Unlocks enemies killed achievements if required condition is satisfied.
        public void CheckForEnemiesKilledAchievement()
        {
            for(int i=0; i < achievementSOList.enemiesKilledAchievementSO.achievements.Length; i++)
            {
                if (i != currentEnemiesKilledAchievementLevel) continue;

                if(PlayerTankService.Instance.GetTankController().tankModel.enemiesKilled == achievementSOList.enemiesKilledAchievementSO.achievements[i].requirement)
                {
                    UnlockAchievement(achievementSOList.enemiesKilledAchievementSO.achievements[i].name, achievementSOList.enemiesKilledAchievementSO.achievements[i].info);
                    currentEnemiesKilledAchievementLevel = i + 1;
                    PlayerPrefs.SetInt("currentEnemiesKilledAchievementLevel", currentEnemiesKilledAchievementLevel);
                }
                break;
            }
        }

        // Unlocks wave survived achievements if required condition is satisfied.
        public void CheckForWavesSurvivedAvhievement()
        {
            for(int i=0; i < achievementSOList.waveSurvivedAchievementSO.achievements.Length; i++)
            {
                if (i != currentWavesSurvivedAchievementLevel) continue;

                if(PlayerTankService.Instance.GetTankController().tankModel.waveSurvived == achievementSOList.waveSurvivedAchievementSO.achievements[i].requirement)
                {
                    UnlockAchievement(achievementSOList.waveSurvivedAchievementSO.achievements[i].name, achievementSOList.waveSurvivedAchievementSO.achievements[i].info);
                    currentWavesSurvivedAchievementLevel = i + 1;
                    PlayerPrefs.SetInt("currentWavesSurvivedAchievementLevel", currentWavesSurvivedAchievementLevel);
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
