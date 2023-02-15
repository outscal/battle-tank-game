using System;
using UnityEngine;
namespace Observer_Pattern
{
    public class AcheivementSystem : Singleton<AcheivementSystem>
    {
        public int bonusBulletsFromAchievement1;
        public int bonusBulletsFromAchievement2;
        public bool infiniteBulletsAchieved;
        public int CurrentBullet = 10;
        public int TotalEnemyDied = 0;
        public void BulletCount(int enemiesDied)
        {
            TotalEnemyDied = enemiesDied;
            Debug.Log("Current Bullet" +CurrentBullet);
            OnAttach();
        }
        public void OnAttach()
        {
            // Check if the player has reached the first achievement
            if (TotalEnemyDied == 3 )
            {
                bonusBulletsFromAchievement1 += 10;
                Debug.Log("Achievement 1 unlocked! Player received 10 extra bullets.");
            }
            // Check if the player has reached the second achievement
            if (TotalEnemyDied == 5 )
            {
                bonusBulletsFromAchievement2 += 50;
                Debug.Log("Achievement 2 unlocked! Player received 50 extra bullets.");
            }
            // Check if the player has reached the infinite bullet achievement
            if (TotalEnemyDied >= 7)
            {
                infiniteBulletsAchieved = true;
                Debug.Log("Achievement 3 unlocked! Player has infinite bullets.");
            }
            if(TotalEnemyDied == EnemySpawner.Instance.maxEnemies)
            {
                EventManagement.Instance.InvokeOnEnemyDeath();
            }
        }
    }
    
}
