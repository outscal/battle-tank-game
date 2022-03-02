using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tank : Singleton_Generic<Player_Tank>
{
    public Joystick Tank_joystick;
    float horizontalInput, verticalInput, speed = 7.0f, rotationSpeed = 150.0f;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        Player_Movement();
    }

    void Player_Movement()
    {
        horizontalInput = Tank_joystick.Horizontal * 5;
        verticalInput = Tank_joystick.Vertical * 5;

        if (horizontalInput > 0 || horizontalInput < 0 || verticalInput > 0 || verticalInput < 0)
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
