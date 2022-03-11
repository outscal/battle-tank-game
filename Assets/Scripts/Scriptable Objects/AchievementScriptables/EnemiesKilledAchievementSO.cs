using System;
using UnityEngine;

namespace AchievementScriptables
{
    [CreateAssetMenu(fileName = "EnemiesKilledAchievementSO", menuName = "ScriptableObject/Achievement/NewEnemiesKilledAchievementSO")]
    public class EnemiesKilledAchievementSO : ScriptableObject
    {
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
