using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Singleton<BulletSpawner>
{
    public BulletList bulletObjectList;
    private Transform spawn;
    public BulletView bulletView;
    private void Update() {
        spawn = this.transform;
    }
    public void SpawnBullet(Transform bulletTransform)
    {
        BulletModel bulletModel = new BulletModel(bulletObjectList.bullets[0]);
        BulletController bulletController = new BulletController(bulletModel, bulletObjectList.bullets[0].bulletView,bulletTransform);
    }
}
