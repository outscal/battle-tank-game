using System;
using UnityEngine;

namespace AchievementSO
{
    [CreateAssetMenu(fileName = "EnemiesKilledAchievementSO", menuName = "ScriptableObject/Achievement/NewEnemiesKilledAchievementSO")]
    public class EnemiesKilledAchievementSO : ScriptableObject
    {
        // To create number of achievements.
        public AchievementType[] achievements;

        [Serializable]
        public class AchievementType
        {
            public enum KillAchievements
            {
                None,
                Assassin,
                Terminator,
                Warmonger,
            }

            public string name;
            public string info;
            public KillAchievements selectAchievement;
            public int requirement;
        }
    }
}
