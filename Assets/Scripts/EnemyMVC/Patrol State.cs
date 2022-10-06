using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Tank;

public class PatrolState : TankState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
    }

    private void Update()
    {
        //if (currPos.z == currDestination.z && currPos.x == currDestination.x)
        //{
        //    tempIndex = Random.Range(0, enemyModel.GetCount());
        //    currDestination = enemyModel.GetPoint(tempIndex);
        //}
        //navMeshAgent.destination = currDestination;
    }


    public override void OnExitState()
    {
        base.OnExitState();
    }

}
