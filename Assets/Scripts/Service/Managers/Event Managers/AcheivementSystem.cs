using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.EventService;
namespace Tank.EventService
{
    public class AcheivementSystem : Singleton<AcheivementSystem>
    {
        private int count = 0;
        private List<string> Achievements;
        private void Start()
        {
            Achievements = new List<String>();
            EventManagement.Instance.OnPlayerShoot += BulletShot;
            EventManagement.Instance.OnEnemyDeath += EnemyWave;
        }

        private void OnDisable()
        {
            EventManagement.Instance.OnPlayerShoot -= BulletShot;
            EventManagement.Instance.OnEnemyDeath -= EnemyWave;
        }
        private void BulletShot()
        { 
            count++;
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
                if (!IsAchiveved(achievement))
                    StartCoroutine(UIManager.Instance.ShowAchievement(achievement));
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
                if (!IsAchiveved(achievement))
                    StartCoroutine(UIManager.Instance.ShowAchievement(achievement));
            }
        }
    }
}
