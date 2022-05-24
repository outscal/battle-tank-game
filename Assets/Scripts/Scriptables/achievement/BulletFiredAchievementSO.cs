using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BulletsFiredAchievementSO", menuName = "ScriptableObjects/Achievement/NewBulletsFiredAchievementSO")]
public class BulletFiredAchievementSO : ScriptableObject
{
    public AchievementType[] achievements;

    [Serializable]
    public class AchievementType
    {
        public enum BulletAchievements
        {
            None,
            JustGettingStarted,
            Destructor,
            Rampage,
        }

        public string name;
        public string info;
        public BulletAchievements selectAchievement;
        public int requirement;
    }
}
