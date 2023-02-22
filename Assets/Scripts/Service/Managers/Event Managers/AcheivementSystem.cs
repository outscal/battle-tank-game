using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.EventService;
namespace Tank.EventService
{
    public class AcheivementSystem : Singleton<AcheivementSystem>
    {
        public List<string> Achievements;
        private void Start()
        {
            EventManagement.OnPlayerShoot += BulletShot;
            EventManagement.OnEnemyDeath += EnemyWave;
        }

        private void OnDisable()
        {
            EventManagement.OnPlayerShoot -= BulletShot;
            EventManagement.OnEnemyDeath -= EnemyWave;
        }
        private void BulletShot()
        { int count = 0;
            bool trigger = true;
            string achievement = "BulletsShot ";
            switch (count)
            {
                case 1:
                    achievement += "1";
                    break;
                case 10:
                    achievement += "10";
                    break;
                case 20:
                    achievement += "20";
                    break;
                default:
                    trigger = false;
                    break;
            }

            if (trigger)
            {
                //if (!IsAchiveved(achievement))
                UIManager.Instance.ShowAchievement(achievement);
            }
        }
    private bool IsAchiveved(string achevementName)
        {
            if (Achievements.Contains(achevementName))
                return true;

            Achievements.Add(achevementName);
            return false;
        }
        private void EnemyWave()
        {
            int count = 0;
            bool trigger = true;
            string achievement = "Enemies killed  ";
            switch (count)
            {
                case 1:
                    achievement += "1";
                    break;
                case 10:
                    achievement += "5";
                    break;
                case 20:
                    achievement += "10";
                    break;
                default:
                    trigger = false;
                    break;
            }
            if (trigger)
            {
                //if (!IsAchiveved(achievement))
                UIManager.Instance.ShowAchievement(achievement);
            }
        }
    }
}
