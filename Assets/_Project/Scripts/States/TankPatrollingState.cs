using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrollingState : TankState
{
    private float timeElapsed;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Patrolling Awake");
    }
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Entering State: TankPatrolling State");
        tankView.ChangeColor(color);
    }
    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("Exiting State: TankPatrolling State");
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > 5f)
        {
            tankView.ChangeState(tankView.tankChasingState);
        }
    }
}
