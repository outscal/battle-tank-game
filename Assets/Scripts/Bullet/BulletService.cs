
using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : GenericSingleton<BulletService> 
{
    Queue<BulletController> bulletControllers = new Queue<BulletController>();
    BulletPool bulletPool;
    public TankController tc;

    public event Action<int> bulletfire;
    private int bulletsFired = 0;

    protected override void Awake()
    {
        base.Awake();
        bulletPool= GetComponent<BulletPool>();
    }
    public void FireBullet(BulletType bulletType, TransformSet bulletTransform)
    {
        bulletPool.createBullet(bulletType,bulletTransform).onFire(bulletTransform);
        ////////
        /*if(bulletControllers.Count <= 0|| bulletControllers.Peek().bulletModel.fired == true)
        {
            createBullet(bulletType, bulletTransform);
        }
        else
        {
            BulletController firedBullet = bulletControllers.Dequeue();
            bulletControllers.Enqueue(firedBullet);
            firedBullet.onFire(bulletTransform);
        }*/
        bulletsFired++;
        bulletfire?.Invoke(bulletsFired);
    }

    public void returnBullet( BulletController bullet)
    {
        bulletPool.retrieveItem( bullet);
    }
    public BulletController createBullet(BulletType _bulletType, TransformSet _bulletTransform)
    {
        BulletModel bulletModel = new BulletModel(_bulletType.speed, _bulletTransform);
        BulletController bulletController = new BulletController(bulletModel, _bulletType.bulletView);
        return bulletController;
        //bulletControllers.Enqueue(bulletController);
    }
 
}
