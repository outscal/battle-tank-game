using System;
using UnityEngine;

namespace BattleTank.AchievementSystemSO
{
    [CreateAssetMenu(fileName = "AchievementScriptableObject", menuName = "ScriptableObjects/NewAchivement")]
    public class AchievementScriptableObject : ScriptableObject
    {
        public Achievement[] AchievementLevels;
    }

    [Serializable]
    public class Achievement
    {
        public string Title;
        public string Description;
        public int Target;
        public int Score;
    }
}