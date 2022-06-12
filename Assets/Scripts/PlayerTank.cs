using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : GenericSingleton<PlayerTank>
{
    [SerializeField] float tankSpeed;
    [SerializeField] float rotationSpeed;    

    private void FixedUpdate()
    {
        TankMovement();

    }
    private void TankMovement()
    {
        float forward= Input.GetAxis("Vertical1") *tankSpeed*Time.deltaTime;
        float tankRoation =Input.GetAxis("Horizontal1"); 
        transform.Translate( 0,0,forward);
        transform.Rotate(0, tankRoation*rotationSpeed, 0);

    }
}
