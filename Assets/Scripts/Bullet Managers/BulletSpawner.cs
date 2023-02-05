using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public BulletList bulletObjectList;
    public BulletView bulletView;
    public void SpawnBullet(Transform bulletTransform)
    {
        BulletModel bulletModel = new BulletModel(bulletObjectList.bullets[0]);
        //BulletModel bulletModel = new BulletModel(20, 30);
        BulletController bulletController = new BulletController(bulletModel, bulletView, bulletTransform);
    }
}
