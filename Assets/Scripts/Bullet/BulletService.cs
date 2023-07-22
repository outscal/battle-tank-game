
using System;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService> 
{
    [SerializeField]
    private BulletView bulletPrefab;

    [SerializeField]
    private BulletScriptableObjectList bulletScriptableObjectList;

    public Action OnPlayerBulletFire;
    public void GenerateBullet(Vector3 pos,Quaternion rotation)
    {
        BulletModel bulletModel = new(bulletScriptableObjectList.bullets[0]);
        BulletController bulletController = new(bulletModel, bulletPrefab, pos, rotation);
    }
}
