namespace EnemyStates
{
    public class IdleState : EnemyState
    {
        public IdleState(EnemyView enemyView) : base(enemyView) { }

        public override void OnStateEnter()
        {
            enemyView.NavMeshAgent.isStopped = true;
        }

        public override void Tick()
        {
            if (enemyView.PlayerInDetectionRange())
            {
                enemyView.SetState(new ChaseState(enemyView));
            }
        }

        public override void OnStateExit()
        {
            enemyView.NavMeshAgent.isStopped = false;
        }
    }
}