using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Joystick : MonoBehaviour
{

    [SerializeField] private Rigidbody tankRB;
    [SerializeField] private FixedJoystick fxJoystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool pc_Controller;
    [SerializeField] private float rotateSpeed;

    private void FixedUpdate()
    {
        if (pc_Controller != true)
        {
            tankRB.velocity = new Vector3(fxJoystick.Horizontal * moveSpeed, tankRB.velocity.y * 0f, fxJoystick.Vertical * moveSpeed);

            if (fxJoystick.Horizontal != 0 || fxJoystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(tankRB.velocity);
            }
        }

        if (pc_Controller == true)
        {
            var transAmount = moveSpeed * Time.deltaTime;
            var rotateAmount = rotateSpeed * Time.deltaTime;

            if (Input.GetKey("up"))
            {
                transform.Translate(0, 0, transAmount);
            }
            if (Input.GetKey("down"))
            {
                transform.Translate(0, 0, -transAmount);
            }
            if (Input.GetKey("left"))
            {
                transform.Rotate(0, -rotateAmount, 0);
            }
            if (Input.GetKey("right"))
            {
                transform.Rotate(0, rotateAmount, 0);
            }
        }
    }
}

    
