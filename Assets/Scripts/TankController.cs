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
    }

    private void TankMovement()
    {
        float vertical = joystick.Vertical;
        float horizontal = joystick.Horizontal;

        transform.position = transform.position + transform.forward * speed * vertical * Time.deltaTime;
        transform.Rotate(Vector3.up * rotate * Time.deltaTime * horizontal);

    }
}

