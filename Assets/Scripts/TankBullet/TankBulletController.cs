using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBulletController 
{
    private TankBulletModel tankBulletModel;
    private TankBulletView tankBulletView;
    public TankBUlletType tankBulletType;

    private GameObject bullet;
    private Transform bulletspwanPos;

    public TankBulletController(TankBulletModel _tankBulletModel, TankBulletView _tankBulletView, Transform spawnPos)
    {
        tankBulletModel = _tankBulletModel;
        tankBulletView = _tankBulletView;
        bulletspwanPos = spawnPos;
        ShootBullet();

    }

    

    public void ShootBullet()
    {
        bullet = GameObject.Instantiate(tankBulletView.gameObject, bulletspwanPos.position, bulletspwanPos.rotation);
        // var bullet = GameObject.Instantiate(tankBulletModel.BulletPrefab, tankBulletModel.BulletSpawnPosition.position, tankBulletModel.BulletSpawnPosition.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletspwanPos.forward * tankBulletModel.BulletSpeed;
    }
    
}
