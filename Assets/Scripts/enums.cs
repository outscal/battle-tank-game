using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public enum EnemyTankType
    {
        None = 0,
        Pink = 1,
        Yellow = 2,
        SkyBlue = 3

    }
public enum BulletType
    {
        None = 0,
        LowDamage = 1,
        MediumDamage = 2,
        HighDamage  = 3

    }

public enum PlayerTankType
    {
        None = 0,
        FirstTank = 1,
        SecondTank = 2,
        ThirdTank = 3

    }

public enum EnemyStates
{
    None = 0,
    Idle=1,
    Patroling=2,
    Chasing=3,
    Attacking =4
}

