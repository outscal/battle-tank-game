using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public TankModel(float speed)
    {
        Debug.Log("Tank model created");
        Speed = speed;
    }

    public float Speed { get; }
}
