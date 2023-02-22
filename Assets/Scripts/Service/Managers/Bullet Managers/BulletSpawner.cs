using System.Collections;
using System.Collections.Generic;
using Tanks.ObjectPool;
using UnityEngine;
public class BulletSpawner : Singleton<BulletSpawner>
{
    public BulletList bulletObjectList;
    private Transform spawn;
    private BulletPool bulletPool;
    public BulletView bulletView;
    private void Start()
    {
        bulletPool = this.gameObject.GetComponent<BulletPool>();
    }
    private void Update() {
        spawn = this.transform;
    }
    public void SpawnBullet(Transform bulletTransform)
    {
        BulletModel bulletModel = new BulletModel(bulletObjectList.bullets[0]);
        bulletPool.GetBullet(bulletModel, bulletObjectList.bullets[0].bulletView, bulletTransform);
    }
}
