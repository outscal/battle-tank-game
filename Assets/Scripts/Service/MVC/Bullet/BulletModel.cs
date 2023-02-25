
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;
    private BulletObject bulletInfo;
    public BulletModel(BulletObject _bulletInfo)
    {
        this.bulletInfo = _bulletInfo;

    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    public float ExplosionRadius
    {
        get
        {
            return bulletInfo.ExplosionRadius;
        }
    }
    public float ExplosionForce
    {
        get
        {
            return bulletInfo.ExplosionForce;
        }
    }
    public float Damage
    {
        get
        {
            return bulletInfo.Damage;
        }
    }
    public float BulletSpeed
    {
        get
        {
            return bulletInfo.Speed;
        }
    }
}
