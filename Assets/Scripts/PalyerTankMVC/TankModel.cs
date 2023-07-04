using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController tankController;
    private float speed;
    public float Speed { get => speed; }

    public TankModel(float _speed)
    {
        speed =  _speed;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
