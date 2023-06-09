using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    TankModel tankModel;
    TankView tankView;
    Rigidbody tankRigidbody;
    public TankController(TankModel _tankmodel, TankView _tankview)
    {
        tankModel = _tankmodel;
        tankView = GameObject.Instantiate<TankView>(_tankview);
        tankRigidbody = tankView.GetRigidbody();

        tankModel.SetTankController(this);
        tankView.SetTankController(this);
    }

    public void Move(float movement, float movementSpeed)
    {
        //tankRigidbody.velocity = tankView.transform.forward * movement * movementSpeed * Time.deltaTime;
        Vector3 Movement = tankView.transform.forward * movement * movementSpeed * Time.deltaTime;
        tankRigidbody.MovePosition(tankRigidbody.position + Movement);
    }

    public void Turn(float rotation, float rotationSpeed)
    {
        float turn = rotation * rotationSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        tankRigidbody.MoveRotation(tankRigidbody.rotation * turnRotation);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }
}
