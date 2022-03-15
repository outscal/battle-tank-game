using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tank : Singleton_Generic<Player_Tank>
{
    public Joystick Tank_joystick;
    float horizontalInput, verticalInput, speed, rotationSpeed, joystick_minMovement;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        speed = 4.0f;
        rotationSpeed = 250.0f;
        joystick_minMovement = 1f;
    }

    private void Update()
    {
        Tank_Movement();
    }

    void Tank_Movement()
    {
        horizontalInput = Tank_joystick.Horizontal * 5;
        verticalInput = Tank_joystick.Vertical * 5;

        if (horizontalInput > joystick_minMovement || horizontalInput < -joystick_minMovement || verticalInput > joystick_minMovement || verticalInput < -joystick_minMovement)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            moveDirection.Normalize();

            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
