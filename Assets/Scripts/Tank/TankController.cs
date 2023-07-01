
using System;
using UnityEngine;

public class TankController 
{

    public TankModel tankModel { get; }
    public TankView tankView { get; }

    private Rigidbody tankRigidBoy;


    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
    }

    public void SetRigidBody(Rigidbody rb)
    {
        tankRigidBoy = rb;
    }

    public void MoveTank(float _move)
    {
        tankRigidBoy.velocity = _move * tankModel.movementSpeed * Time.deltaTime * tankView.transform.forward;
    }

    public void RotateTank(float _rotation)
    {
        Vector3 rotate = new (0f,_rotation * tankModel.rotationSpeed,0f);
        Quaternion deltaRotaion = Quaternion.Euler(rotate * Time.deltaTime);
        tankRigidBoy.MoveRotation(tankRigidBoy.rotation * deltaRotaion);
    }
}
