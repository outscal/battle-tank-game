using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoGenericSingleton<BulletService>
{
    public BulletView _bulletView;
    public BulletSO[] _bulletScriptableObjects;

    private void Start()
    {
        CreateNewBullet();
    }

    private void CreateNewBullet()
    {
        //creating a bullet model
        BulletSO bulletScriptableObject = _bulletScriptableObjects[Random.Range(0, _bulletScriptableObjects.Length)];
        BulletModel bulletModel = new BulletModel(bulletScriptableObject);

        //spawning the bullet using the created bullet model
        BulletController bulletController = new BulletController(bulletModel, _bulletView);
    }
}