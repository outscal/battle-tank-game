
using System;
using UnityEngine;

public class BulletController 
{
    private BulletView bulletView;
    public BulletModel BulletModel { get; private set; }
    public BulletController(BulletModel bulletModel,BulletView bulletView,Vector3 pos,Quaternion rotation)
    {
        this.BulletModel = bulletModel;
        this.bulletView = GameObject.Instantiate<BulletView>(bulletView, pos, rotation);
        this.bulletView.SetBullerControler(this);
    }

    public void MoveForword()
    {
        bulletView.Rb.velocity = BulletModel.Speed * Time.deltaTime * bulletView.transform.forward;

    }

}
