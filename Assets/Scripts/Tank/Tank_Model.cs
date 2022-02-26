using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Model
{
    public Tank_Model(int speed, float health)
    {
        Speed = speed;
        Health = health;
        Debug.Log("Tank_Model()");
    }
    public int Speed { get; }
    public float Health { get; }
}
