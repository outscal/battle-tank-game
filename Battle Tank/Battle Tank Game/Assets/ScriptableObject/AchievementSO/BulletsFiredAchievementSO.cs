using System;
using UnityEngine;

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
