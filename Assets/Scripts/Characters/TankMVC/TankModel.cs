using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController _controller;
    private TankScriptableObject _tankScriptableObject;
    public int Speed { get; private set; }
    public int Health { get; private set; }
    public float Rotationspeed { get; private set; }
    public TankType TankType { get; private set; }

    public TankModel(int speed,int health) {
        Speed = speed;
        Health = health;
    
    }
    public TankModel(TankScriptableObject tankSO)
    {
        _tankScriptableObject = tankSO;
        this.Speed=(int)tankSO.speed;
        this.Health=(int)tankSO.health;
        this.Rotationspeed=(int)tankSO.rotationspeed;
        this.TankType = tankSO.TankType;
        this.Damage = (int)tankSO.Damage;
    }
    public void SetTankController(TankController tankController)
    {
        _controller = tankController;
    }

    public void SetHealth(int health)
    {
        this.Health = (int)health;
    }

    public int SpeedLive { get{ return (int)_tankScriptableObject.speed; } }

    public int Damage { get; internal set; }
}
