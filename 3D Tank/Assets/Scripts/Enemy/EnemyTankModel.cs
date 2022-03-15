using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Summary//
//Script for intialising the data to Enemy Tank Model
//-Summary//
public class EnemyTankModel
{
    public EnemyTankModel(EnemyTankStats stats)
    {
        Health = stats.maxHealth;
        Attack = stats.attackPower;
    }
    public int Health { get; set; }
    public int Attack { get; }
}