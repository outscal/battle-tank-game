using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "EnemiesKilledAchievementSO", menuName = "ScriptableObjects/Achievement/NewEnemiesKilledAchievementSO")]
public class EnemiesKilledAchievementSO : ScriptableObject
{
    public AchievementType[] achievements;

    [Serializable]
    public class AchievementType
    {
        public enum KillAchievements
        {
            None,
            TheyProbablyDeservedIt,
            MurderousTendencies,
            QuestionableMoral,
        }

        public string name;
        public string info;
        public KillAchievements selectAchievement;
        public int requirement;
    }
}
