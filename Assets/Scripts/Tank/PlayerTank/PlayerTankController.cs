
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerTankController 
{

    public PlayerTankModel tankModel { get; }
    public PlayerTankView tankView { get; }

    private Rigidbody tankRigidBoy;



    public PlayerTankController(PlayerTankModel _tankModel, PlayerTankView _tankView, Vector3 pos)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<PlayerTankView>(_tankView,pos,_tankView.transform.rotation);
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
    }

    public void SetRigidBody(Rigidbody rb)
    {
        tankRigidBoy = rb;
    }

    public void MoveTank(float _move)
    {
        tankRigidBoy.velocity = _move * tankModel.MovementSpeed * Time.deltaTime * tankView.transform.forward;
    }

    public void RotateTank(float _rotation)
    {
        Vector3 rotate = new (0f,_rotation * tankModel.RotationSpeed,0f);
        Quaternion deltaRotaion = Quaternion.Euler(rotate * Time.deltaTime);
        tankRigidBoy.MoveRotation(tankRigidBoy.rotation * deltaRotaion);
    }

    public void FireBullet(Vector3 pos)
    {
        BulletService.Instance.GenerateBullet(tankView,pos);
    }

}
