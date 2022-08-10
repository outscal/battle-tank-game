using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    public float RotationSpeed { get; }
    public float MovementSpeed { get; }
    public TankType TankType { get;  }

    // TankModel -> controller
    public void SetTankControllerReference(TankController _tankController)
    {
        tankController = _tankController;
    }

    public TankModel(TankType tankType, float movement, float rotationSpeed)
    {
        TankType = tankType;
        MovementSpeed = movement;
        RotationSpeed = rotationSpeed;
    }
}
