
using UnityEngine;

public class BulletModel
{
    public int BulletDamage { get; }
    public int BulletSpeed { get; }
    public float MaxLifeTime { get; }
    public float ExplosionRadius { get; }
    public float ExplosionForce { get; }

    public BulletModel(int damage, int bulletSpeed)
    {
        BulletDamage = damage;
        BulletSpeed = bulletSpeed;
        MaxLifeTime = 3f;
        ExplosionRadius = 5f;
        ExplosionForce = 1000f;
    }

}
