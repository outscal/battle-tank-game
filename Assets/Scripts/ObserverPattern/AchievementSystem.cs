using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
   
    void BulletsFiredAchievement(int bulletCount)
    {
        switch(bulletCount)
        {
            case 10:
                UIManager.instance.tenBullets.SetActive(true);
                UIManager.instance.bulletAchievemntText.text = "10 bullets fired";
                break;
            case 20:
                UIManager.instance.tenBullets.SetActive(true);
                UIManager.instance.bulletAchievemntText.text = "20 bullets fired";
                break;
            case 30:
                UIManager.instance.tenBullets.SetActive(true);
                UIManager.instance.bulletAchievemntText.text = "30 bullets fired";
                break;
            default:
                UIManager.instance.tenBullets.SetActive(false);
                break;
        }
    }


    private void Start()
    {
        TankBulletService.Instance.bulletFiredbyPlayer += BulletsFiredAchievement;
    }

    private void OnDisable()
    {
        TankBulletService.Instance.bulletFiredbyPlayer -= BulletsFiredAchievement;
    }
}
