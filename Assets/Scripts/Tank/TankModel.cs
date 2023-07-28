using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController ;
    public Transform shootertransform;
    public int defaultSpeed;
    public int speed;
    public float health;
    public BulletType bulletType;
    public TankModel(int _speed, float _health, BulletType _bulletType)
    {
        defaultSpeed = _speed;
        health = _health;
        speed = defaultSpeed;
        bulletType = _bulletType;
    }

    

    public void getTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
