using UnityEngine;
using System;

namespace AchievementSO
{
    [CreateAssetMenu(fileName = "AchievementHolder", menuName = "ScriptableObject/Achievement/NewAchievementListSO")]
    public class AchievementSOList : ScriptableObject
    {
        public BulletFiredAchievementSO bulletsFiredAchievementSO;
        public EnemiesKilledAchievementSO enemiesKilledAchievementSO;
    }
}
