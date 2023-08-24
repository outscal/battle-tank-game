using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCtrl : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Rigidbody playerrb;


    private void Start()
    {
        playerrb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TankMovement();
    }

    private void TankMovement()
    {
        float vertical = joystick.Vertical;
        float horizontal = joystick.Horizontal;

        Vector3 movement = transform.forward * vertical * speed * Time.deltaTime;

        // Check for any movement input (both vertical and horizontal)
        if (vertical != 0 || horizontal != 0)
        {
            Vector3 inputDirection = new Vector3(horizontal, 0.0f, vertical).normalized;
            float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;

            // Smoothly rotate the character using Quaternion.RotateTowards
            Quaternion targetQuaternion = Quaternion.Euler(0.0f, targetRotation, 0.0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);
        }

        // Move the character using rigidbody
        playerrb.MovePosition(transform.position + movement);
    }
}
