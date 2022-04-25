using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
            Shots_Fired,
            Destructor,
            Terminator,
        }

        public string name;
        public string info;
        public BulletAchievements selectAchievement;
        public int requirement;
    }
}



