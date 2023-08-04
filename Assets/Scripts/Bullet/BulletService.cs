
using System.Collections.Generic;
using UnityEngine;

public class BulletService : GenericSingleton<BulletService> 
{
    Queue<BulletController> bulletControllers = new Queue<BulletController>();


    public void FireBullet(BulletType bulletType, TransformSet bulletTransform)
    {
        if(bulletControllers.Count <= 0|| bulletControllers.Peek().bulletModel.fired == true)
        {
            createBullet(bulletType, bulletTransform);
        }
        else
        {
            BulletController firedBullet = bulletControllers.Dequeue();
            bulletControllers.Enqueue(firedBullet);
            firedBullet.onFire(bulletTransform);
        }
    }

    private void createBullet(BulletType _bulletType, TransformSet _bulletTransform)
    {
        BulletModel bulletModel = new BulletModel(_bulletType.speed, _bulletTransform);
        BulletController bulletController = new BulletController(bulletModel, _bulletType.bulletView);
        bulletControllers.Enqueue(bulletController);
    }
 
}
