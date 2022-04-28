using UnityEngine;

namespace AchievementScriptables
{
    [CreateAssetMenu(fileName = "AchievementHolder", menuName = "AchievementScriptables/AchievementHolder", order = 1)]
    public class AchievementHolder : ScriptableObject
    {
        public BulletsFiredAchievementSO bulletsFiredAchievementSO;
        public EnemiesKilledAchievementSO enemiesKilledAchievementSO;
    }
}