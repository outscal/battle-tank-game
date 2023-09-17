using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public TankModel(int speed, float health)
    {
        Speed = speed;
        Health = health;
    }

    public int Speed { get; }
    public float Health { get; }
}
