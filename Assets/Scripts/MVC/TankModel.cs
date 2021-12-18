using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
/*    public int Speed { get; private set; }*/
    public float Health { get; }
    public TankModel (int speed, float health)
    {
/*        Speed = speed;*/
        Health = health;
    }
    void Start()
    {
        
    }
}
