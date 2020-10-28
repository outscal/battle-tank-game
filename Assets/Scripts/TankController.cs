using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public FixedJoystick joystick;
  //  private float horizontalMove;
   // private float verticalMove;

    public float speed;
    public float rotate;


    private void Update()
    {
        TankMovement();
        TankRotate();
    }

    private void TankMovement()
    {
        float vertical = joystick.Vertical;
        if (vertical > .3f || vertical < -.3f)
        {
            transform.position = transform.position + transform.forward * speed * vertical * Time.deltaTime;
        }

    }
    private void TankRotate()
    {
        float horizontal = joystick.Horizontal;
        if(horizontal > .3f || horizontal < -.3f)
        transform.Rotate(Vector3.up * rotate * Time.deltaTime * horizontal);
    }
}

