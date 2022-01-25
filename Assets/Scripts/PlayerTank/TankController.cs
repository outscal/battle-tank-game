using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoSingletonGeneric<TankController>
{
    [SerializeField]
    private Joystick joystick;

    [SerializeField]
    private Rigidbody rigidbody;

    private float dirX, dirY;

    [Range(0,10f)] [Tooltip("Tank's speed")]  
    private float moveSpeed; 

    void Start()
    {
        moveSpeed = 0.2f; 
    }

    void Update()
    {
        dirX = joystick.Horizontal * moveSpeed;
        dirY = joystick.Vertical * moveSpeed;

        rigidbody.transform.localPosition += Vector3.forward * dirY;
        rigidbody.transform.localPosition -= Vector3.right * -dirX;
    }
}
