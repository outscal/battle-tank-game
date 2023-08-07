using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateChase : TankState
{
    private TankState nextTankState;
    public StateChase(EnemyTankController _tankController) : base(_tankController)
    {
        tankState = TankStates.chase;
    }

    public override void onStateEnter()
    {
        base.onStateEnter();
    }

    public override void onTick()
    {
        base.onTick();
        tankController.lookAtPlayer();
        tankController.moveForward();
        float reqDistance = tankController.distanceBtwPlayer();
        if (reqDistance > 10)
        {
            nextTankState = new StateIdle(tankController);
            onStateExit();
        }
        if (reqDistance <= 5)
        {
            nextTankState = new StateAttack(tankController);
            onStateExit();
        }
    }

    public override void onCollision()
    {

    }

    public override void onStateExit()
    {
        base.onStateExit();
        tankController.changeState(nextTankState);
    }

}
