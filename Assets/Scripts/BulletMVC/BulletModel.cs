using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;
    public BulletModel(float bulletSpeed, float bulletDamage, Transform bulletTransform)
    {
        BulletSpeed = bulletSpeed;
        BulletDamage = bulletDamage;
        BulletTransform = bulletTransform;
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }


    public float BulletSpeed
    {
        get;
    }

    public float BulletDamage
    {
        get;
    }

    public Transform BulletTransform
    {
        get;
    }
}
