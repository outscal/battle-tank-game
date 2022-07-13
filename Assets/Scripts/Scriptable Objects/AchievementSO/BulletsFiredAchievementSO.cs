using System;
using UnityEngine;

namespace AchievementSO
{
    [CreateAssetMenu(fileName = "BulletsFiredAchievementSO", menuName = "ScriptableObject/Achievement/NewBulletsFiredAchievementSO")]
    public class BulletsFiredAchievementSO : ScriptableObject
    {
        // To create number of achievements.
        public AchievementType[] achievements;

        [Serializable]
        public class AchievementType
        {
            public enum BulletAchievements
            {
                None,
                Gunslinger,
                Destructor,
                RainOfFire,
            }

            public string name;
            public string info;
            public BulletAchievements selectAchievement;
            public int requirement;
        }
    }
}
