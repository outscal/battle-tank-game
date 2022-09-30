using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletModel(float bulletSpeed, float bulletDamage, Transform bulletTransform)
    {
        BulletSpeed = bulletSpeed;
        BulletDamage = bulletDamage;
        BulletTransform = bulletTransform;
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
