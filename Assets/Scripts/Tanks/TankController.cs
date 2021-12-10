using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private Rigidbody rb;
    public TankModel TankModel { get; private set; }
    public TankView tankView { get; private set; }

    public TankController(TankModel tankModel, TankView tankView)
    {
        TankModel = tankModel;
        tankView = GameObject.Instantiate<TankView>(tankView);
        rb = tankView.GetComponent<Rigidbody>();
        tankView.SetTankController(this);
        TankModel.SetTankController(this);
    }

    public void Move(float movement, float movementSpeed)
    {
        Vector3 move = tankView.transform.forward * movement * movementSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + move);
    }

    public void Rotate(float rotation, float rotateSpeed)
    {
        float rotate = rotation * rotateSpeed * Time.deltaTime;
        Quaternion turn = Quaternion.Euler(0f, rotate, 0f);
        rb.MoveRotation(rb.rotation * turn);
    }
}
