using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTScriptableObject
{
    [CreateAssetMenu(fileName = "AchievementList", menuName = "ScriptableObj/AchievementList", order = 4)]
    public class AchievementScriptable : ScriptableObject
    {
        public List<Achievement> achievements;
    }

    public enum AchievementType { hiScore, gamesPlayed, enemyKilled }
    public enum AchievementStatus { Locked, Unlocked }

    [System.Serializable]
    public struct Achievement
    {
        public string AchievementName;
        public AchievementType achievementType;
        public List<AchievementInfo> achievementInfo;
    }

    [System.Serializable]
    public struct AchievementInfo
    {
        public string achievementTitle;
        public int achievementRequirement;
        public AchievementStatus achievementStatus;
    }
}