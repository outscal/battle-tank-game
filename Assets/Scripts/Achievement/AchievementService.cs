using System;
using UnityEngine;

namespace Achievement
{
    public class AchievementService: SingletonMB<AchievementService>
    {
        #region Serialized Data members

        [SerializeField] private Scriptable_Object.Achievement.AchievementSystem achievements;

        #endregion

        #region Getters

        public Scriptable_Object.Achievement.AchievementSystem Achievement => achievements;

        #endregion

        #region Unity Functions

        protected override void Awake()
        {
            base.Awake();
            achievements.Subscribe();
        }
        
        private void OnDisable()
        {
            achievements.Unsubscribe();
        }

        #endregion
    }
}