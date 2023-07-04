
using System;
using UnityEngine;

public class BulletController 
{
    private BulletView bulletView;
    public BulletModel bulletModel { get; private set; }
    public BulletController(BulletModel bulletModel,BulletView bulletView,Vector3 pos,Quaternion rotation)
    {
        this.bulletModel = bulletModel;
        this.bulletView = GameObject.Instantiate<BulletView>(bulletView, pos, rotation);
        this.bulletView.SetBullerControler(this);
    }

    public void SetInitialVelocity()
    {
        bulletView.rb.velocity = bulletModel.speed * bulletModel.tankView.transform.forward;
    }
    public void MoveForword()
    {
        bulletView.rb.velocity = bulletModel.speed * Time.deltaTime * bulletView.transform.forward;

    }

    public void RemoveReferenceFromPlayerTankController()
    {
        bulletModel.tankView.tankController.RemoveBullet(this);
    }
}
