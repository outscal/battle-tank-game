using BattleTank.Enum;
using BattleTank.Services;

namespace BattleTank.StateMachine.EnemyState
{
    public class DeadState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public DeadState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.NavMeshAgent.isStopped = true;
            ParticleEffectsService.Instance.ShowExplosionEffect(ExplosionType.TankExplosion, enemyStateMachine.EnemyTankView.transform.position);
            enemyStateMachine.DestroyGameObject();
            stateMachine.SetState(null);
        }
    }
}