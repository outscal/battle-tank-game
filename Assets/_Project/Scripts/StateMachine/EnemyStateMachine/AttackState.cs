using BattleTank.Enum;
using BattleTank.Services;
using UnityEngine;

namespace BattleTank.StateMachine.EnemyState
{
    public class AttackState : BaseState
    {
        private float waitTime;
        private float nextShootTime;
        private EnemyStateMachine enemyStateMachine;

        public AttackState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
            nextShootTime = 5f;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.NavMeshAgent.isStopped = false;
            waitTime = 0f;
        }

        public override void Tick()
        {
            waitTime += Time.deltaTime;
            if(waitTime > nextShootTime)
            {
                waitTime = 0f;
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