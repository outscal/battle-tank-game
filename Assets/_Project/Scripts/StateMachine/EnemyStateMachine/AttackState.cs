using BattleTank.Enum;
using BattleTank.Services;
using UnityEngine;

namespace BattleTank.StateMachine.EnemyState
{
    public class AttackState : BaseState
    {
        private float nextShootTime;
        private float waitTime;
        private float defaultWaitTime;
        private EnemyStateMachine enemyStateMachine;

        public AttackState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
            nextShootTime = enemyStateMachine.GetNextShootTime();
            defaultWaitTime = enemyStateMachine.GetDefaultWaitTime();
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.NavMeshAgent.isStopped = false;
            waitTime = defaultWaitTime;
        }

        public override void Tick()
        {
            waitTime += Time.deltaTime;
            if(waitTime > nextShootTime)
            {
                waitTime = defaultWaitTime;
                SpawnBullet();
            }

            if (enemyStateMachine.IsPlayerTankInAttackRange())
            {
                enemyStateMachine.NavMeshAgent.SetDestination(enemyStateMachine.PlayerTransform.position);
                enemyStateMachine.transform.LookAt(enemyStateMachine.PlayerTransform.position);
            }
            else
            {
                stateMachine.SetState(enemyStateMachine.ChaseState);
            }
        }

        private void SpawnBullet()
        {
            BulletService.Instance.SpawnBullet(enemyStateMachine.EnemyBulletType, enemyStateMachine.EnemyTankView.GetBulletTransform(), enemyStateMachine.EnemyTankView.transform.rotation, TankID.Enemy);
        }
    }
}