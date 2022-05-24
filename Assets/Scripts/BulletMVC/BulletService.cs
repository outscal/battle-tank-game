using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is responsible to Create, Destroy & Manage all the Bullet MVCs in the game.
/// </summary>
public class BulletService : SingletonGeneric<BulletService>
{
    public BulletScriptableObjectList bulletSOList;
    public BulletViewList bulletViewList;
    public TankService tankService;

    //private BulletType Btype;

    // This Function is used to Create a Bullet MVC which puts the bullet in motion as well.
    public void FireBullet(Transform BulletSpawner, BulletType bulletType)
    {

        //tankService.TType = (int)Btype;

        bulletType = (BulletType)tankService.TType;
        BulletModel bulletModel = new BulletModel(bulletSOList.BulletSOList[(int)bulletType]);
        BulletController bulletController = new BulletController(bulletModel, bulletViewList.bulletViewList[(int)bulletType], BulletSpawner);
    }

}
