using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    public float RotationSpeed { get; }
    public float MovementSpeed { get; }

    // TankModel -> controller
    public void SetTankControllerReference(TankController _tankController)
    {
        tankController = _tankController;
    }

    public TankModel(float movement, float rotationSpeed)
    {
        MovementSpeed = movement;
        RotationSpeed = rotationSpeed;
    }
}
