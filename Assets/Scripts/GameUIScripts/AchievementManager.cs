using UnityEngine;
using BattleTank.Events;

namespace BattleTank.Achievement
{
    public class AchievementManager : MonoBehaviour
    {
        private int bulletCount;
        private int enemiesDestroyedCount;

        [SerializeField] private AchievementScript achievementPrefab;

        void Start()
        {
            bulletCount = 0;
            enemiesDestroyedCount = 0;

            EventService.Instance.OnPlayerFiredBullet += PlayerBulletAchievement;
            EventService.Instance.OnDistanceTravelled += DistanceTravelledAchievement;
            EventService.Instance.OnEnemyDestroy += EnemyDeathAchievement;
        }

        public void PlayerBulletAchievement()
        {
            bulletCount++;

            switch (bulletCount)
            {
                case 10: UnlockAchievement("10 Bullets fired!"); break;
                case 25: UnlockAchievement("25 Bullets fired!"); break;
                case 50: UnlockAchievement("50 Bullets fired!"); break;
                default: break;
            }
        }

        public void EnemyDeathAchievement()
        {
            enemiesDestroyedCount++;

            switch (enemiesDestroyedCount)
            {
                case 1: UnlockAchievement("First enemy destroyed!"); break;
                case 5: UnlockAchievement("Five enemies destroyed!"); break;
                case 10: UnlockAchievement("Ten enemies destroyed!"); break;
                default: break;
            }
        }

        public void DistanceTravelledAchievement(float distance)
        {
            UnlockAchievement($"Distance Travelled {distance}!");
        }

        public void UnlockAchievement(string _achievement)
        {
            AchievementScript newAchievement = Instantiate<AchievementScript>(achievementPrefab);
            newAchievement.transform.SetParent(this.transform);
            newAchievement.SetLocalTransform();
            newAchievement.SetMessage(_achievement);
            newAchievement.ShowcaseAchievement();
        }

        void OnDestroy()
        {
            EventService.Instance.OnPlayerFiredBullet -= PlayerBulletAchievement;
            EventService.Instance.OnDistanceTravelled -= DistanceTravelledAchievement;
            EventService.Instance.OnEnemyDestroy -= EnemyDeathAchievement;
        }
    }
}
