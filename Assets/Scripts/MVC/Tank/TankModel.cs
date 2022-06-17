using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    //tank properties
    public float MovementSpeed { get; }
    public float RotationSpeed { get; }
    public float Health { get; }
    public Joystick Joystick { get; }

    TankController _tankController;

    //constructor
    public TankModel(float movementSpeed, float rotationSpeed, float health)
    {
        MovementSpeed = movementSpeed;
        RotationSpeed = rotationSpeed;
        Health = health;
    }


    public void SetController(TankController tankController)
    {
        _tankController = tankController;
    }



}