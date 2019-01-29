using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType { slow, medium, fast }

public class BulletManager : Singleton<BulletManager>
{
    [SerializeField]
    private BulletType bulletType = new BulletType();

    public BulletType Bullet_Type
    {
        get { return bulletType; }
    }

    public BulletController bulletController { get; private set; }
	

    public void SpawnBullet(Vector3 direction, Vector3 spawnPos, Vector3 rotation)
    {
        if(bulletType == BulletType.fast)
            bulletController = new FastBulletController();
        else if (bulletType == BulletType.medium)
            bulletController = new MediumBulletController();
        else if (bulletType == BulletType.slow)
            bulletController = new SlowBulletController();

        bulletController.SpawnBullet(direction, spawnPos, rotation);
    }


}
