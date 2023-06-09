using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    TankController tankController;

    float speed;
    float turnSpeed;

    public TankModel(float Speed, float TurnSpeed)
    {
        speed = Speed;
        turnSpeed = TurnSpeed;
    }
}
