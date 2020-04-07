using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public BulletView bulletView;
    private Vector3 spawnPos;

    protected override void Awake()
    {
        base.Awake();
      
    }

    public void spawnBullet()
    {
        BulletModel bulletModel = new BulletModel(20);
        BulletController bullet = new BulletController(bulletModel, bulletView, this);
    }

}
