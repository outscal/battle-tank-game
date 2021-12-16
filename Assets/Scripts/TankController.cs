using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoSingletonGeneric <TankController>
{
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 40f;
    private float moveSpeed, dirX, dirY;
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private Rigidbody rb;

    void Start()
    {
        moveSpeed = 0.2f;
    }
    private void FixedUpdate()
    {
            rb.transform.localPosition += Vector3.forward * dirY;
            rb.transform.localPosition += Vector3.right * dirX;
    }
    private void Update()
    {
        dirX = joystick.Horizontal * moveSpeed;
        dirY = joystick.Vertical * moveSpeed;
    }
}













/*            if (joystick.Horizontal >= .2f)
            {
                horizontalMove = runSpeed;
            }
            else if (joystick.Horizontal <= -.2f)
            {
                horizontalMove = -runSpeed;
            }
            else
            {
                horizontalMove = 0f;
            }
            if (joystick.Vertical >= .2f)
            {
                verticalMove = runSpeed;
            }
            else if (joystick.Vertical <= -.2f)
            {
                verticalMove = -runSpeed;
            }
            else
            {
                verticalMove = 0f;
            }*/