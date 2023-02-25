using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
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
        //BulletModel bulletModel = new BulletModel(20, 30);
        BulletController bulletController = new BulletController(bulletModel, bulletObjectList.bullets[0].bulletView,spawn);
    }
}
