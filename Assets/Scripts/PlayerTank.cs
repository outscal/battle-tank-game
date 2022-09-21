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
        horizontalInput = joystick.Horizontal; //Input.GetAxisRaw("HorizontalUI") ;
        verticalInput = joystick.Vertical;//Input.GetAxisRaw("VerticalUI");
        if(horizontalInput>0.2f)
        {
            moveVector.x = transform.position.x + movSpeed * Time.deltaTime;
        }
        else if(horizontalInput<(-0.2f))
        {
            moveVector.x = transform.position.x + (-1) * movSpeed * Time.deltaTime;
        }

        if(verticalInput>0.2f)
        {
            moveVector.z = transform.position.z + movSpeed * Time.deltaTime;
        }
        else if(verticalInput<(-0.2f))
        {
            moveVector.z = transform.position.z + (-1) * movSpeed * Time.deltaTime;
        }
        transform.position = moveVector;
        
    }

    

}
