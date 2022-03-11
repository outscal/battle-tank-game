using System;
using UnityEngine;

namespace AchievementScriptables
{
    [CreateAssetMenu(fileName = "BulletsFiredAchievementSO", menuName = "ScriptableObject/Achievement/NewBulletsFiredAchievementSO")]
    public class BulletsFiredAchievementSO : ScriptableObject
    {
        public AchievementType[] achievements;

        [Serializable]
        public class AchievementType
        {
            public enum BulletAchievements
            {
                None,
                Destructor,
                BulletsFiringDragon,
                FireInaHole,
            }

            public string name;
            public string info;
            public BulletAchievements selectAchievement;
            public int requirement;
        }
    }
}
