
using UnityEngine;

public class TankModel
{
    public float TurnSpeed;
    private float health;
    private TankController tankController;
    private TankObject tankObject;
    
    public TankModel(TankObject _tankObject)
    {
        this.tankObject = _tankObject;
        TurnSpeed = tankObject.TurnSpeed;
        health = tankObject.Health;
    }

    public TypeDamagable Type
    {
        get{return tankObject.Type;}
    }
    public void SetTankController(TankController tankcontroller)
    {
        tankController = tankcontroller;
    }
    public float Speed
    {
        get
        {
            return tankObject.Speed;
        }
    }

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health =  (int)value;
        }
    }
    public TankType tankType
    {
        get
        {
            return tankObject.tankType;
        }
    }
    public Material color
    {
        get
        {
            return tankObject.color;
        }
    }
}
