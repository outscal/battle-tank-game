using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolService : GenericPoolService<BulletController>
{
    private BulletView bulletView;
    public BulletController GetBullet(BulletView _bulletView)
    {
        bulletView = _bulletView;
        return GetItem();
    }
    protected override BulletController CreateItem()
    {
        BulletService.Instance.BulletRandomizer();
        BulletController bullet = new BulletController(new BulletModel(BulletService.Instance.BulletRandomizer()), bulletView,TankService.Instance.GetbulletTransform());
        return bullet;
    }
}
