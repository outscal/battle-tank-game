using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel 
{
   public BulletModel(int speed, float damage)
    {
        Speed = speed;
        Damage = damage;
    }

    public int Speed { get; }
    public float Damage { get; }
}
