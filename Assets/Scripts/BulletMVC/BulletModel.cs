using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletModel(float bulletSpeed, float bulletDamage)
    {
        BulletSpeed = bulletSpeed;
        BulletDamage = bulletDamage;
    }

    public float BulletSpeed
    {
        get;
    }

    public float BulletDamage
    {
        get;
    }

}
