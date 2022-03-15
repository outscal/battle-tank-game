using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Summary//
//Script for intialising the data to Tank Model
//-Summary//
public class TankModel 
{

   public TankModel(TankStats stats)
    {
        Health = stats.maxHealth;
        Attack = stats.attackPower;
    }
    public int Health { get; set; }
    public int Attack { get; }
}
