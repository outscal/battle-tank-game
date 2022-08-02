using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    // JoyStick & rigidbody Reference
    [SerializeField] private Joystick joyStick;
    [SerializeField] private Rigidbody rb;

    // Speed variables
    [SerializeField]  private float playerTankMoveSpeed;

    // This Function Handles the Input from the Joystick
    private void FixedUpdate()
    {
       rb.velocity = new Vector3(joyStick.Horizontal * playerTankMoveSpeed, rb.velocity.y, joyStick.Vertical * playerTankMoveSpeed);

        if (joyStick.Horizontal != 0 || joyStick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
}
