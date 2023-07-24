
using System;
using UnityEngine;

public class BulletController 
{
    public BulletView BulletView { get; private set; }
    public BulletModel BulletModel { get; private set; }
    public BulletController(BulletModel bulletModel,BulletView bulletView)
    {
        this.BulletModel = bulletModel;
        this.BulletView = GameObject.Instantiate<BulletView>(bulletView);
        this.BulletView.SetBullerControler(this);
    }

    public void SetPosition(Vector3 pos)
    {
        BulletView.transform.position = pos;
    }
    public void SetRotation(Quaternion rotation)
    {
        BulletView.transform.rotation = rotation;
    }
    public void MoveForword()
    {
        BulletView.Rb.velocity = BulletModel.Speed * Time.deltaTime * BulletView.transform.forward;

    }

}
