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
        bulletspwanPos = spawnPos;
        tankBulletView = GameObject.Instantiate<TankBulletView>(_tankBulletView, bulletspwanPos.position, bulletspwanPos.rotation);
        tankBulletView.SetTankBulletController(this);
        ShootBullet();
    }

    

    public void ShootBullet()
    {
    //  bullet = GameObject.Instantiate(tankBulletView.gameObject, bulletspwanPos.position, bulletspwanPos.rotation);
        tankBulletView.GetComponent<Rigidbody>().velocity = bulletspwanPos.forward * tankBulletModel.BulletSpeed;
    }

    public int BulletDamage()
    {
        return tankBulletModel.BulletDamage;
    }
    
}
