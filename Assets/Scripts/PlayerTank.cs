using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : GenericSingleton<PlayerTank>
{
    [SerializeField] float movSpeed = 5f;
    [SerializeField] float rotationSpeed= 5f ;
    [SerializeField] Joystick joystick;
    float horizontalInput, verticalInput;
    float requiredAngle;
    Vector3 moveVector = Vector3.zero; //to avoid reinitialization of memory with every update
    private void Awake() //simple implementation
    {
        base.MakeSingleton();
    }

    private void Update()
    {
        if(joystick.Direction.magnitude > 0)
            transform.position += transform.forward * movSpeed * Time.deltaTime ;
        moveVector.x = joystick.Direction.x;
        moveVector.z = joystick.Direction.y;
        transform.forward = moveVector;
    }

    

}
