using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public TankType TankType { get; }
    public float Speed { get; }
    public float Health { get; }
    public Color Color { get; }
   // TankDataSO tankData;


    public TankModel(TankType tankType, float speed, float health, Color color)
    {
        TankType = tankType;
        Speed = speed;
        Health = health;
        Color = color;
    }

  
    public void UpdateTankView()
    {




    }


}
