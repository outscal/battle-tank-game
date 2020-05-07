using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Event;
using TankGame.UI;

public class SaveSystemService : MonoSingletonGeneric<SaveSystemService>
{
    private int FiredBullets;
    private int KilledEnemies;

    protected override void Start()
    {
        base.Start();
        EventService.Instance.BulletFired += SaveBulletFired;
        EventService.Instance.EnemyDeath += SaveEnemyKilled;
    }


    private void SaveBulletFired(int bulletCount)
    {
            FiredBullets = bulletCount;
            PlayerPrefs.SetInt("FiredBullets", FiredBullets);
            UIService.Instance.ShowBulletFiredUI();
    }
    private void SaveEnemyKilled(int deathCount)
    {
            KilledEnemies = deathCount;
            PlayerPrefs.SetInt("KilledEnemies", KilledEnemies);
            UIService.Instance.ShowEnemyKilledUI();
    }
}
