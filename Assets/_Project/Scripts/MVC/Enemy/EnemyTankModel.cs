using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel : TankModel
{
    public float EnemyTankSpeed { get; }
    public float startWaitTime = 4;
    public float timeToRotate = 2;
    public float SpeedWalk { get; }
    public float SpeedRun { get; }
    public EnemyTankModel(TankScriptableObject tankScriptableObject) : base(tankScriptableObject)
    {
        SpeedWalk = tankScriptableObject.speed / 2;
        SpeedRun = tankScriptableObject.speed;
    }
}
