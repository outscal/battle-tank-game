using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tank : MonoBehaviour
{
    public Joystick joystick;
    public CharacterController characterController;

    public float speed=40f;
    [SerializeField]
    private float rotationSpeed=3f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    public void SetJoystick(Joystick Move)
    {
        joystick = Move;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTank();
       
    }
    private void MoveTank()
    {
        Vector3 move = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        characterController.Move(move * Time.deltaTime *speed);
        Quaternion targetRotation = Quaternion.LookRotation(move, Vector3.up);

        // Smoothly interpolate the rotation using Lerp
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
