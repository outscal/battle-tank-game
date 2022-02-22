using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private Rigidbody rb;
    public Transform bulletSpawnpoint;
    private float movement, rotation;
    public TankTypes tankType;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void setTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
    private void Update()
    {
        move();
        //    Shoot();

    }
    private void FixedUpdate()
    {
        // Vector3 move = transform.forward * movement * tankController.tankModel.Speed * Time.deltaTime;
        // rb.MovePosition(rb.position + move);
        // float rotate = rotation * tankController.tankModel.Speed * Time.deltaTime;
        // Quaternion turn = Quaternion.Euler(0f, rotate, 0f);
        // rb.MoveRotation(rb.rotation * turn);

    }
    private void move()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }
    // private void Shoot()
    // {
    //     if (Input.GetButtonDown("Fire1"))
    //     {

    //     }

    // }

}