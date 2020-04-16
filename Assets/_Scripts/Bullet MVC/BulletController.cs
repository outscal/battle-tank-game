using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    public BulletModel BulletModel { get; }
    public BulletView BulletView { get; }

    public BulletController(BulletModel bulletModel, BulletView bulletView, Vector3 position)
    {
        Debug.Log("Bullet Controller created");
        BulletModel = bulletModel;
        BulletView = GameObject.Instantiate<BulletView>(bulletView, position + bulletModel.OffsetY, new Quaternion(0f,0f,0f,0f));

        BulletView.SetBulletController(this);
    }

    public void FireBullet(Vector3 tankRotation)
    {
        BulletView.FireBullet(tankRotation);
    }
}
