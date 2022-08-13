using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is responsible to Create, Destroy & Manage all the Bullet MVCs in the game.
/// </summary>

public class BulletService : GenericSingleton<BulletService>
{
    public BulletScriptableObjectList bulletScriptableObjectList;
    public BulletViewList bulletViewList;

    // This Function is used to Create a Bullet MVC which puts the bullet in motion as well.
    public void FireBullet(Transform BulletSpawner, BulletType bulletType)
    {
        BulletModel bulletModel = new BulletModel(bulletScriptableObjectList.bulletScriptableObjectList[(int)bulletType - 1]);
        BulletController bulletController = new BulletController(bulletModel, bulletViewList.bulletViewList[(int)bulletType - 1], BulletSpawner);
    }
}