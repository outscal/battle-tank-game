using System;
using Achievement;
using UnityEngine;

namespace Scriptable_Object.Achievement
{
    [CreateAssetMenu(fileName = "NewAchievementSystem", menuName = "User/Achievement/AchievementSystem", order = 0)]
    public class AchievementSystem : ScriptableObject
    {
        #region Serialized Data Members;

        [SerializeReference] private global::Achievement.AchievementCell[] achievements;

        #endregion

        #region Private Data Members

        private int _lastLength;

        #endregion
        
        #region Unity Functions

        private void Awake()
        {
            _lastLength = 0;
        }
        
        private void OnValidate()
        {
            if (achievements.Length > _lastLength)
            {
                achievements[_lastLength] = new AchievementCell(); 
                
            }
            _lastLength = achievements.Length;
            UpdateAchievement();
        }

        #endregion

        #region Private Functions

        private void UpdateAchievement()
        {
            foreach (var cell in achievements)
            {
                cell.UpdateCell();
            }
        }

        #endregion

        #region Getters

        public AchievementCell[] Achievements => achievements;

        #endregion

        #region Public Funcitons

        public void Subscribe()
        {
            foreach (var achievement in achievements)
            {
                achievement.Achievement.Subscribe();
                achievement.Achievement.Reset();
            }
        }

        public void Unsubscribe()
        {
            foreach (var achievement in achievements)
            {
                achievement.Achievement.Unsubscribe();
            }
        }
        

        #endregion
    }
}