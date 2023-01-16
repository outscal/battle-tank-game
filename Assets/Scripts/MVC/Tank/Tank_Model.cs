using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Model 
{
    //private Tank_Ctrl tankcontroller;
    //public float movementSpeed;
    //public float rotationSpeed;
    //public float Health;


    public Tank_Model(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
        RotationSpeed = tankScriptableObject.RotationSpeed;

    }
    //public Tank_Model(TankType tankType, float _movement, float _rotation)
    //{
    //    movementSpeed = _movement;
    //    rotationSpeed = _rotation;
    //}

    public TankType TankType { get; }
    public int Speed { get; }
    public float Health { get; }

    public float RotationSpeed { get; }

    //public void SetTankController(Tank_Ctrl _tankCtrl)
    //{
    //    tankcontroller = _tankCtrl;
    //}
}
