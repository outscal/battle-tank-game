using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private float movement, rotation;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector3 move = transform.forward * movement * tankController.TankModel.MovSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + move);

        float rotate = rotation * tankController.TankModel.RotSpeed * Time.deltaTime;
        Quaternion turn = Quaternion.Euler(0f, rotate, 0f);
        rb.MoveRotation(rb.rotation * turn);

        //tankController.Move(movement, tankController.TankModel.MovSpeed);
        //tankController.Rotate(rotation, tankController.TankModel.RotSpeed);
    }

    public void SetTankController(TankController tankControl)
    {
        tankController = tankControl;
    }
}
