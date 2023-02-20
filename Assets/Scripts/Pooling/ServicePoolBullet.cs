using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePoolBullet : ServicePool<TankBulletController>
{
    private TankBulletModel tankBulletModel;
    private TankBulletView tankBulletPrefab;
    private Transform tankBulletSpawnPos;

    public TankBulletController GetBullet(TankBulletModel tankBulletModel, TankBulletView tankBulletPrefab, Transform tankBulletSpawnPos)
    {
        this.tankBulletModel = tankBulletModel;
        this.tankBulletPrefab = tankBulletPrefab;
        this.tankBulletSpawnPos = tankBulletSpawnPos;
        return GetItem();
    }
    protected override TankBulletController CreateItem()
    {
        TankBulletController tankBulletController = new TankBulletController(tankBulletModel, tankBulletPrefab, tankBulletSpawnPos);
        return tankBulletController;
    }
}
