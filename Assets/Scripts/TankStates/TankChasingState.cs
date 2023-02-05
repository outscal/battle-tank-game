
public class TankChasingState : TankState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        agent.isStopped = false;
    }

    private void Update()
    {
        if(enemyView.enemyController.IsInShootingRange())
        {
            enemyView.enemyController.ChangeState(GetComponent<TankShootingState>());
            return;
        }
        if(!enemyView.enemyController.IsInChaseRange())
        {
            enemyView.enemyController.ChangeState(GetComponent<TankPatrollingState>());
            return;
        }
        enemyView.enemyController.ChasingPlayer();
    }

    //public override void OnExitState()
    //{
    //    base.OnExitState();   
    //}


}
