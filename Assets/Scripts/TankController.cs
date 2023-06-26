using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Joystick joystick;
    public float speed;

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (joystick.Horizontal >= 0.2f)
        {
            transform.position += speed * Time.deltaTime * Vector3.right;
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            transform.position += speed * Time.deltaTime * Vector3.left;
        }
        if(joystick.Vertical >= 0.02f)
        {
            transform.position += speed * Time.deltaTime * Vector3.forward;
        }
        else if(joystick.Vertical <= -0.2f)
        {
            transform.position += speed * Time.deltaTime * Vector3.back;

        }


    }
}
