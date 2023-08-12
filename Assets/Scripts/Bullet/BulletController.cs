using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    public BulletModel bulletModel { get; }
    public BulletView bulletView { get; }
    public BulletController(BulletModel _bulletModel, BulletView _bulletView) 
    {
        bulletModel= _bulletModel;
        bulletModel.getTankController(this);
        bulletView = GameObject.Instantiate<BulletView>(_bulletView,_bulletModel.bulletTransform.position, bulletModel.bulletTransform.rotation);
        bulletView.getTankController(this);
        onFire(_bulletModel.bulletTransform);
    }
    public void onFire(TransformSet _bulletTransform)
    {
        prepareBullet(_bulletTransform);
        exertForce(_bulletTransform.velocity);
    }
    public void onHit()
    {
        bulletView.gameObject.SetActive(false);
        bulletView.bulletRb.velocity= Vector3.zero;
        bulletView.gameObject.transform.position = Vector3.zero;
        bulletModel.fired = false;
    }
    private void prepareBullet(TransformSet _bulletTransform)
    {

        bulletModel.bulletTransform = _bulletTransform;
        bulletView.transform.position = bulletModel.bulletTransform.position;
        bulletView.transform.rotation = bulletModel.bulletTransform.rotation;
        bulletModel.fired = true;
        bulletView.gameObject.SetActive(true);
    }
    private void exertForce(Vector3 shooterVelocity)
    {
        bulletView.bulletRb.velocity = bulletView.gameObject.transform.forward  * (bulletModel.speed + shooterVelocity.magnitude);
    }
}


public interface IgetController
{
    public void getTankController(BulletController bulletController);
}

