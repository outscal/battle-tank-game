using UnityEngine;

public class TankShootingState : TankState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        agent.isStopped = true;
    }

    private void Update()
    {
        
        Debug.Log("Is in Shooting State");
        if (!enemyView.enemyController.IsInShootingRange())
        {
            enemyView.enemyController.ChangeState(GetComponent<TankPatrollingState>());
            return;
        }
        enemyView.enemyController.Shooting();
    }
}
