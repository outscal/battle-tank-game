using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public TankModel(int moveingSpeed, int rotatingSpeed, float health, Color tankColor)
    {
       
        MoveingSpeed = moveingSpeed;
        RotatingSpeed = rotatingSpeed;
        Health = health;
        TankColor = tankColor;
    }

    public int MoveingSpeed { get; }
    public int RotatingSpeed { get; }
    public float Health { get; }
    public Color TankColor { get; }
}
