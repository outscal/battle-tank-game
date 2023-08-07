using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(TankView))]
public class StateIdle : TankState
{
    private TankState nextTankState;
    public StateIdle(EnemyTankController _tankController) : base(_tankController)
    {
        tankState = TankStates.idle;
    }

    public override void onStateEnter()
    {
        base.onStateEnter();
        
    }

    public override void onStateExit()
    {
        base.onStateExit();
        tankController.changeState(nextTankState);
    }

    /*private async Task<bool> IdleForSeconds()
    {
        bool proceed;
        float time = 0;

        time += Time.deltaTime;
        proceed = CalculateSecs(5f);
        await proceed; 
    }*/

    private bool CalculateSecs( float waitingTime)
    {
        float time = 0;
        time += Time.deltaTime;
        if (time > waitingTime)
        {
            return true;
        }
        return false;
    }

    


    public override void onTick()
    {
        base.onTick();
        tankController.shiftDirectionSlow();
        float reqDistance = tankController.distanceBtwPlayer();

        if (reqDistance > 10)
        {
            nextTankState = new StatePatrolling(tankController);
            onStateExit();
        }
        else if(reqDistance <= 10)
        {
            nextTankState = new StateChase(tankController);
            onStateExit();
        }
        
    }
}