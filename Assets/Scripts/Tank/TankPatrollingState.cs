using UnityEngine;

public class TankPatrollingState : TankState
{
    private float timeElapsed;

    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Entering state: Patrolling");
        enemyTankView.enemyController.EnemyMechanism();
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("Entering state: Patrolling");
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > 5f)
        {
            enemyTankView.ChangeState(enemyTankView.chasingState);
        }
    }
}
    

