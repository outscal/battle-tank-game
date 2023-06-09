using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
    public TankModel(float moveSpeed, float TurnSpeed)
    {
        movementSpeed = moveSpeed;
        rotationSpeed = TurnSpeed;
    }
}
