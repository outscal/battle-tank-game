using BattleTank.AchievementSystemSO;

namespace BattleTank.AchievementSystem
{
    public class AchievementModel
    {
        public int CurrentScore;
        public int CurrentLevel;
        public Achievement[] AchievementLevel { get; private set; }

        public AchievementModel(AchievementScriptableObject _achievementScriptableObject)
        {
            CurrentScore = 0;
            CurrentLevel = 0;
            AchievementLevel = _achievementScriptableObject.AchievementLevels;
        }
    }
}