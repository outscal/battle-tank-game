using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoGenericSingleton<Achievement>
{
    private int BulletFiredAchievement;
    private int EnemyKilledAchievement;
    public Text achievement_Text;
    private Text displayText;



    void start()
    {
        BulletFiredAchievement = PlayerPrefs.GetInt("BulletFiredAchievement",0);
        EnemyKilledAchievement = PlayerPrefs.GetInt("EnemyKilledAchievement",0);
    }

    public void CheckForBulletFiredAchievement(int currentBulletFired)
    {
        switch(currentBulletFired)
        {
            case 1:     Debug.Log("You Fired Your First Bullet");
                        break; 
            case 5:     Debug.Log("You Fired 5 Bullet");
                        break;
            case 10:    Debug.Log("You Fired 10 Bullet");
                        break;
            default:
                        break;
        }
    }
}

