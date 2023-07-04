using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTankToJoyStick : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float runSpeed = 40f;

    private float horizontalmove = 0f;
    private float verticalMove = 0f;


    

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal * runSpeed,rb.velocity.y,joystick.Vertical * runSpeed);
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
}
 