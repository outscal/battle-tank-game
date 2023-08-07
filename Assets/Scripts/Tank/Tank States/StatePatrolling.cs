using System;
using UnityEngine;

[Serializable]
public class StatePatrolling : TankState
{
    private TankState nextTankState;
    public StatePatrolling(EnemyTankController _tankController) : base(_tankController)
    {
        tankState = TankStates.patrolling;
    }

    public override void onCollision()
    {
        tankController.shiftDirectionSlow();
    }
    public override void onStateEnter()
    {

    }

    public override void onStateExit()
    {
        base.onStateExit();
        tankController.changeState(nextTankState);
    }

    public override void onTick()
    {
        tankController.moveForward();
        tankController.throwRay();
        if (tankController.distanceBtwPlayer() <= 5)
        {
            nextTankState = new StateAttack(tankController);
            onStateExit();
        }
    }
}