using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ServicePool<BulletController>
{
    private BulletModel bulletModel;
    private BulletView bulletPrefab;
    private Vector3 position;
    private Quaternion rotation;
    public BulletController GetBulletPool(BulletModel bulletModel, BulletView bulletPrefab, Vector3 position, Quaternion rotation)
    {
        this.bulletModel = bulletModel;
        this.bulletPrefab = bulletPrefab;
        this.position = position;
        this.rotation = rotation;
        return GetItem();
    }
    protected override BulletController CreateItem()
    {
        BulletController bulletController = new BulletController(bulletModel, bulletPrefab, position, rotation);
        return bulletController;
    }
}
