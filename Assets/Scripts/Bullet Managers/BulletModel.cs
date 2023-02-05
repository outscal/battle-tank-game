
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;
    public float bulletSpeed;
    public float bulletDamage;
    public BulletModel(BulletObject bulletInfo)
    {
        bulletSpeed = bulletInfo.Speed;
        bulletDamage = bulletInfo.Damage;
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
