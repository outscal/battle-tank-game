using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletModel(float speed, float damage, Vector3 offsetY)
    {
        Debug.Log("Bullet Model created");
        Speed = speed;
        Damage = damage;
        OffsetY = offsetY;
    }

    public Vector3 OffsetY { get; }
    public float Speed { get; }
    public float Damage { get; }
}
