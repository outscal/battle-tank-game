using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TankState
{
    protected EnemyTankController tankController;
    protected TankStates tankState;
    public TankState(EnemyTankController _tankController)
    {
        tankController= _tankController;
    }
    public virtual void onStateEnter()
    {

    }

    public virtual void onTick()
    {

    }

    public virtual void onCollision()
    {

    }

    public virtual void onStateExit()
    {

    }

    ~TankState()
    {

    }
}

public enum TankStates { idle, patrolling, chase, attack }

