using GameEvents;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField]
    private int enemyKillThreshold;

    [SerializeField]
    private int bulletShotThreshold;

    private int enemyKillCounter = 0;
    private int bulletShotCounter = 0;

    private bool enemyKillAchievementUnlocked = false;
    private bool bulletShotAchievementUnlocked = false;

    private void Start()
    {
        enemyKillCounter = PlayerPrefs.GetInt("enemiesKilled", 0);
        bulletShotCounter = PlayerPrefs.GetInt("bulletsShot", 0);
        enemyKillAchievementUnlocked = enemyKillCounter > enemyKillThreshold;
        bulletShotAchievementUnlocked = bulletShotCounter > bulletShotThreshold;
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.enemyKilled += RegisterEnemyKill;
        GameEventsManager.Instance.bulletShot += RegisterBulletShot;
    }
    private void RegisterEnemyKill()
    {
        enemyKillCounter++;
        PlayerPrefs.SetInt("enemiesKilled", enemyKillCounter);
        CheckForAchievements();
    }
    private void RegisterBulletShot()
    {
        bulletShotCounter++;
        PlayerPrefs.SetInt("bulletsShot", bulletShotCounter);
        CheckForAchievements();
    }

    private void CheckForAchievements()
    {
        CheckEnemyKillAchievement();
        CheckBulletsShotAchievement();
    }

    private void CheckEnemyKillAchievement()
    {
        if (enemyKillCounter >= enemyKillThreshold && !enemyKillAchievementUnlocked)
        {
            AchievementUIManager.Instance.DisplayAchievement($"Kill {enemyKillThreshold} Enemies");
            enemyKillAchievementUnlocked = true;
        }
    }

    private void CheckBulletsShotAchievement()
    {
        if (bulletShotCounter >= bulletShotThreshold && !bulletShotAchievementUnlocked)
        {
            AchievementUIManager.Instance.DisplayAchievement($"Shoot {bulletShotThreshold} Bullets");
            bulletShotAchievementUnlocked = true;
        }
    }
}
