using UnityEngine;

namespace AchievementSO
{
    // Stores different types of achievement scriptable objects.
    [CreateAssetMenu(fileName = "AchievementHolder", menuName = "ScriptableObject/Achievement/NewAchievementListSO")]
    public class AchievementHolder : ScriptableObject
    {
        public BulletsFiredAchievementSO bulletsFiredAchievementSO;
        public EnemiesKilledAchievementSO enemiesKilledAchievementSO;
        public WaveSurvivedAchievementSO waveSurvivedAchievementSO;
    }
}
