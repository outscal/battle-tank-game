using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "EnemiesKilledAchievementScriptableObject", menuName = "ScriptableObjects/Achievement/NewEnemiesKilledAchievementScriptableObject")]
public class enemiesKilledAchievementSO : ScriptableObject
{
    public AchievementType[] achievements;

    [Serializable]
    public class AchievementType
    {
        public enum KillAchievements
        {
            None,
            HumbleBrag,
            DemonSock,
            Bloodthirsty,
        }

        public string name;
        public string info;
        public KillAchievements selectAchievement;
        public int requirement;
    }
}
