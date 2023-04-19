using System.Collections;
using System.Collections.Generic;
using Tanks.ObjectPool;
using UnityEngine;
public class BulletSpawner : Singleton<BulletSpawner>
{
    [SerializeField] private BulletList bulletObjectList;
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
    public void SpawnBullet(Transform bulletTransform,TypeDamagable shooter)
    {
        BulletController bullet = bulletPool.GetBullet(bulletObjectList.bullets[0], bulletTransform);
        bullet.ActivateObject(bulletTransform, shooter);
    }
}
