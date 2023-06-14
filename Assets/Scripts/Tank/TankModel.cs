using BattleTank.camera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;
    public TankType tankType;

    public Camera camera;

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        tankType = tankScriptableObject.TankType;
        movementSpeed = tankScriptableObject.Speed;
        rotationSpeed = 180f;
    }
    public TankModel(TankType tankType, float moveSpeed, float TurnSpeed, Camera camera)
    {
        tankType = TankType.None;
        movementSpeed = moveSpeed;
        rotationSpeed = TurnSpeed;
        this.camera = camera;
    }

    public float MovementSpeed { get { return movementSpeed; } }

}
