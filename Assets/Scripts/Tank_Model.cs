using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Model 
{
    private Tank_Ctrl tankcontroller;
    public float movementSpeed;
    public float rotationSpeed;

    public Tank_Model(float _movement, float _rotation)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
    }

    public void SetTankController(Tank_Ctrl _tankCtrl)
    {
        tankcontroller = _tankCtrl;
    }
}
