
using System;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService> 
{
    public BulletView BulletPrefab;
    public BulletModel BulletModel;

    [SerializeField]
    private BulletScriptableObjectList bulletScriptableObjectList;

    public Action OnPlayerBulletFire;
    
    private BulletPoolService bulletPool;
    private void Start()
    {
        bulletPool = new();
    }

    public void GenerateBullet(Vector3 pos,Quaternion rotation)
    {
        BulletModel = new(bulletScriptableObjectList.bullets[0]);
        //BulletController bulletController = new(bulletModel, bulletPrefab, pos, rotation);
        BulletController bulletController = bulletPool.GetBullet();
        bulletController.SetPosition(pos);
        bulletController.SetRotation(rotation);
        bulletController.BulletView.gameObject.SetActive(true);
    }

    public void DeleteBullet(BulletController bulletController)
    {
        bulletPool.ReturnItem(bulletController);
    }
}
