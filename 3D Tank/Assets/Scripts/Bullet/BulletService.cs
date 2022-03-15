using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //Summary//
    //Script Responsible for processing the bullet data
    //-Summary/
public class BulletService : GenericSingleton<BulletService>
{

    public BulletView bulletView;

    public BulletStats[] stats;

    public BulletController InitiateBullet1()     //processing the data for bullet prefab
    {
        BulletStats Stats = stats[2];
        BulletModel model = new BulletModel(Stats);
        BulletController bullet = new BulletController(model, bulletView, TankController.Instance.shootPoint);
        return bullet;
    }
    public BulletController InitiateBullet2()     //processing the data for enemy bullet prefab
    {
        BulletStats Stats = stats[1];
        BulletModel model = new BulletModel(Stats);
        BulletController bullet = new BulletController(model, bulletView, EnemyTankView.Instance.shootpos);
        return bullet;
    }
}

