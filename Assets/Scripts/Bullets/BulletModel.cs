using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletSO;
public class BulletModel
{
    public int bulletDamage { get; }
    public int bulletSpeed { get; }
    public float maxLifeTime;
    public float explosionRadius;



    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
        bulletDamage = bulletScriptableObject.BulletDamage;
        bulletSpeed = bulletScriptableObject.BulletSpeed;
        maxLifeTime = bulletScriptableObject.MaxLifeTime;
        explosionRadius = bulletScriptableObject.ExplosionRadius;

    }
}