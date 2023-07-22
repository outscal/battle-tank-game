using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank
{
    public class AchievementSystem : GenericSingleTon<AchievementSystem>
    {
        public List<string> Achieved;

        public AchievementSystem()
        {
            Achieved = new List<string>();
        }
        private void OnEnable()
        {
            ServiceEvents.instance.OnBulletFire -= BulletShotAchievement;
            ServiceEvents.instance.OnEnemyDeath -= EnemyKilledAchievement;
        }
        private void BulletShotAchievement(int count)
        {
            bool trigger = true;
            string achievementName = "ShellShot";
            string achHeading = "";
            string achSubText = "";
            switch (count)
            {
                case 1:
                    achievementName += "1";
                    achHeading = "First Shell";
                    achSubText = "Shoot you first Shell";
                    break;
                case 10:
                    achievementName += "10";
                    achHeading = "Shell Shooter Novice";
                    achSubText = "Shoot 10 Shells";
                    break;
                case 20:
                    achievementName += "20";
                    achHeading = "Shell Shooter Pro";
                    achSubText = "Shoot 20 Shells";
                    break;
                default:
                    trigger = false;
                    break;
            }
            if (trigger)
            {
                if (!IsAchiveved(achievementName))
                    UIService.Instance.ShowAchievement(achHeading, achSubText);
            }
        }
        private bool IsAchiveved(string achevementName)
        {
            if (Achieved.Contains(achevementName))
                return true;

            Achieved.Add(achevementName);
            return false;
        }
        private void EnemyKilledAchievement(int count)
        {
            bool trigger = true;
            string achievementName = "EnemyKilled";
            string achHeading = "";
            string achSubText = "";
            switch (count)
            {
                case 1:
                    achievementName += "1";
                    achHeading = "First Kill";
                    achSubText = "Kill you Enemy Shell";
                    break;
                case 2:
                    achievementName += "2";
                    achHeading = "Enemy Killer Novice";
                    achSubText = "Kill 2 Enemy";
                    break;
                case 3:
                    achievementName += "3";
                    achHeading = "Enemy Exterminator";
                    achSubText = "Kill All Enemies";
                    break;
                default:
                    trigger = false;
                    break;
            }
            if (trigger)
            {
                if (!IsAchiveved(achievementName))
                    UIService.Instance.ShowAchievement(achHeading, achSubText);
            }
        }
    }
}
