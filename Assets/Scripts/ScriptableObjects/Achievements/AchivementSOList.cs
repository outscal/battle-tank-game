using UnityEngine;

namespace AchievementSO
{
    [CreateAssetMenu(fileName = "AchievementHolder", menuName = "ScriptableObject/Achievement/NewAchievementListSO")]
    public class AchievementHolder : ScriptableObject
    {
        public BulletsFiredAchievementSO bulletsFiredAchievementSO;
        public EnemiesKilledAchievementSO enemiesKilledAchievementSO;
    }
}
