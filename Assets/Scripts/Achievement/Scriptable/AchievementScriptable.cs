using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTScriptableObject
{
    [CreateAssetMenu(fileName = "AchievementList", menuName = "ScriptableObj/AchievementList", order = 4)]
    public class AchievementScriptable : ScriptableObject
    {
        public List<Achievement> achievementList;
    }

    public enum AchievementType { hiScore, gamesPlayed, enemyKilled }
    public enum AchievementStatus { Locked, Unlocked }

    [System.Serializable]
    public struct AchievementInfo
    {
        public string achievementTitle;
        public int achievementRequirement;
        public AchievementStatus achievementStatus;
    }

    [System.Serializable]
    public struct Achievement
    {
        public string AchievementName;
        public AchievementType AchievementType;
        public AchievementInfo achievementInfo;
    }
}