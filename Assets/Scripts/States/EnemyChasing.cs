public class EnemyChasing : EnemyStates
{
    public override void OnEnterState()
    {
        base.OnEnterState();

    }

    private void Update()
    {

        if (!enemyTankView.playerInSightRange && !enemyTankView.playerInAttackRange) enemyTankView.ChangeState(enemyTankView.patrollingState);

        else if (enemyTankView.playerInSightRange && enemyTankView.playerInAttackRange) enemyTankView.ChangeState(enemyTankView.attackingState);

        ChasePlayer();

    }
    public override void OnExitState()
    {
        base.OnExitState();
    }
    // to chasing tankplayer
    private void ChasePlayer()
    {

        if (!enemyTankView.tankPlayer)
        {
            enemyTankView.ChangeState(enemyTankView.patrollingState);
            return;
        }
        enemyTankView.navMeshAgent.SetDestination(enemyTankView.tankPlayer.position);


    }

}