using System;
using UnityEngine;

namespace Achievement
{
    [System.Serializable]
    public class AchievementCell
    {
        #region Serialized Data Members

        [SerializeField] private AchievementType achievementType;
        [SerializeReference] private Achievement achievement;

        #endregion

        #region Private Data Members

        private AchievementType _lastType;

        #endregion

        #region Constructors

        #endregion

        #region Private Functions

        private void UpdateAchievement()
        {
            switch (achievementType)
            {
                case AchievementType.None:
                    achievement = null;
                    break;
                case AchievementType.Fire_x_From_Y_Bullet:
                    achievement = new FireXFromYBullet();
                    break;
                case AchievementType.Stay_Alive_For_X_Time:
                    achievement = new StayAliveForXSeconds();
                    break;
                case AchievementType.Kill_X_Tanks:
                    achievement = new KillXTanks();
                    break;
            }
        }

        #endregion

        #region Getters

        public Achievement Achievement => achievement;

        #endregion

        #region PublicFunction

        public void UpdateCell()
        {
            if (_lastType != achievementType)
            {
                UpdateAchievement();
                _lastType = achievementType;
            }
        }
        
        #endregion
    }
}