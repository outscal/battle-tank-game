using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public int Speed { get; }
    public int Health { get; }
    public TankModel(int speed , int health)
    {
        Speed = speed;
        Health = health;
    }

}
