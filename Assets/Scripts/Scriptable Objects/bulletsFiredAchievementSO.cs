using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BulletFiredAchievementScriptableObject", menuName = "ScriptableObjects/Achievement/NewBulletFiredAchievementScriptableObject")]
public class bulletFiredAchievementSO : ScriptableObject
{
    public AchievementType[] achievements;

    [Serializable]
    public class AchievementType
    {
        public enum BulletAchievements
        {
            None,
            Elite,
            Warhammer,
            Destructor,
        }

        public string name;
        public string info;
        public BulletAchievements selectAchievement;
        public int requirement;
    }
}



