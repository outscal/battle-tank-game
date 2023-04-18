using BattleTank.AchievementSystemSO;
using BattleTank.Enum;
using BattleTank.Services;
using UnityEngine;

namespace BattleTank.AchievementSystem
{
    public class AchievementSystem : MonoBehaviour
    {
        [SerializeField] private AchievementScriptableObject bulletFired;
        [SerializeField] private AchievementScriptableObject tankDestroyed;
        [SerializeField] private AchievementScriptableObject escapeFromEnemyRange;
        private AchievementModel bulletFiredModel;
        private AchievementModel tankDestroyedModel;
        private AchievementModel escapeFromEnemyRangeModel;

        private void Start()
        {
            bulletFiredModel = new AchievementModel(bulletFired);
            tankDestroyedModel = new AchievementModel(tankDestroyed);
            escapeFromEnemyRangeModel = new AchievementModel(escapeFromEnemyRange);

            EventService.Instance.onBulletFired += BulletFiredAchievement;
            EventService.Instance.onTankDestroyed += TankDestroyedAchievement;
            EventService.Instance.onPlayerEscaped += PlayerEscapedAchievement;
        }

        private void BulletFiredAchievement(TankID tankID)
        {
            if(tankID == TankID.Player)
            {
                UpdateAchievement(bulletFiredModel);
            }
        }

        private void TankDestroyedAchievement(TankID shooter, TankID reciever)
        {
            if(shooter == TankID.Player && reciever == TankID.Enemy)
            {
                ScoreService.Instance.UpdateTankDestroyedScore();
                UpdateAchievement(tankDestroyedModel);
            }
        }

        private void PlayerEscapedAchievement()
        {
            UpdateAchievement(escapeFromEnemyRangeModel);
        }

        private void UpdateAchievement(AchievementModel achievementModel)
        {
            int currentLevel = achievementModel.CurrentLevel;
            if (currentLevel != achievementModel.AchievementLevel.Length)
            {
                achievementModel.CurrentScore++;

                if (achievementModel.CurrentScore == achievementModel.AchievementLevel[currentLevel].Target)
                {
                    string title = achievementModel.AchievementLevel[currentLevel].Title;
                    string description = achievementModel.AchievementLevel[currentLevel].Description;

                    UIService.Instance.DisplayAchievement(title, description);
                    ScoreService.Instance.UpdateScore(achievementModel.AchievementLevel[currentLevel].Score);
                    achievementModel.CurrentLevel++;
                }
            }
        }
    }
}