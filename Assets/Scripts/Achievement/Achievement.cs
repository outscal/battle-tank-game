using System;

namespace Achievement
{
    [System.Serializable]
    public abstract class Achievement
    {
        #region Public Events

        public static event Action<Achievement> AchievementAccomplished; 

        #endregion
        
        
        #region Protected Functions

        protected void InvokeAchievement(Achievement achievement)
        {
            AchievementAccomplished?.Invoke(achievement);
        }
        protected abstract void UpdateAchievement();

        #endregion

        #region Public Functions

        public abstract void Subscribe();

        public abstract void Unsubscribe();
        public abstract string Text();

        public abstract void Reset();

        #endregion
    }
}