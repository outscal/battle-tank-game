using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController ;
    public TankModel(int speed, float health)
    {
        Speed = speed;
        Health = health;
        
    }

    public int Speed;
    public float Health;

    public void getTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
