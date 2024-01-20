using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TankModel
{
    private TankController tankController ;
    [SerializeField] public Transform shootertransform;
    public int defaultSpeed;
    public int speed;
    public float health;
    public BulletType bulletType;
    public bool died;
    public TankState currentState;
    public bool firing = false;
    public float distanceCovered;

    public TankModel(int _speed, float _health, BulletType _bulletType, TankState _defaultState)
    {
        defaultSpeed = _speed;
        health = _health;
        speed = defaultSpeed;
        bulletType = _bulletType;
        died = false;
        currentState = _defaultState;
    }
    public TankModel(int _speed, float _health, BulletType _bulletType)
    {
        defaultSpeed = _speed;
        health = _health;
        speed = defaultSpeed;
        bulletType = _bulletType;
        died = false;
    }



    public void getTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
