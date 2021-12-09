using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerAndroid : MonoSingletonGeneric<TankControllerAndroid>
{
    [SerializeField]
    private Joystick joystick;

    [SerializeField]
    private new Rigidbody rigidbody;

    private float dirX, dirY, moveSpeed;

    private void Start()
    {
        moveSpeed = 0.2f;
    }

    private void Update()
    {
        dirX = joystick.Horizontal * moveSpeed;
        dirY = joystick.Vertical * moveSpeed;

        rigidbody.transform.localPosition += Vector3.forward * dirY;
        rigidbody.transform.localPosition += Vector3.right * dirX;

         // rigidbody.velocity += new Vector3(dirX, 0, dirY);
    }

}
