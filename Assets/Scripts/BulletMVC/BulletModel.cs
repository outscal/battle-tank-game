using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Function stores & is used to reference the data about a Bullet entity.
/// </summary>
public class BulletModel
{
    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
        BulletType = bulletScriptableObject.bulletType;
        Damage = bulletScriptableObject.Damage;
        Speed = bulletScriptableObject.speed;
        this.maxLifeTIme = bulletScriptableObject.maxLifeTime;
    }

    public BulletType BulletType { get; }
    public int Damage { get; }
    public float Speed { get; }
    public float maxLifeTIme { get; }
}