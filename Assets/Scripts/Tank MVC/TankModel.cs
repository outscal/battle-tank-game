using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController tankController;
    private float rotationSpeed = 20;
    private float speed = 10;

    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public float Speed { get => speed; set => speed = value; }

    // TankModel -> controller
    public void SetTankControllerReference(TankController _tankController)
    {
        tankController = _tankController;
    }
}
