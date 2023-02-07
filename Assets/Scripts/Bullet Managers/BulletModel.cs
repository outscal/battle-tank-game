
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;
    public float bulletSpeed;
    public float bulletDamage;
    public float ExplosionRadius;
    public float ExplosionForce;
    public BulletModel(BulletObject bulletInfo)
    {
        bulletSpeed = bulletInfo.Speed;
        bulletDamage = bulletInfo.Damage;
        ExplosionForce = bulletInfo.ExplosionForce;
        ExplosionRadius = bulletInfo.ExplosionRadius;
    }
    public BulletModel(float _bulletSpeed, float _bulletDamage)
    {
        bulletSpeed = _bulletSpeed;
        bulletDamage = _bulletDamage;
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}
