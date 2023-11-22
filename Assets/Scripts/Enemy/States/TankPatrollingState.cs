using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrollingState : EnemyState
{
    private float timeElapsed;
    public override void OnEnterState(){
        base.OnEnterState();
        enemyView.ChangeColor(color);
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }

    private void Update(){
        timeElapsed += Time.deltaTime;
        if(timeElapsed > 5f){
            // enemyView.ChangeState(GetComponent<TankChasingState>());
            enemyView.ChangeState(enemyView.chasingState);
        }
    }
}
