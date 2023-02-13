using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Tanks.Tank;
namespace Tanks.Tank
{
    public class EnemyPatrolState : EnemyStates
    {
        public EnemyPatrolState (EnemyView _enemy) : base(_enemy)
        {
            enemy = _enemy;
        }
        public override void OnEnterState()
        {
            base.OnEnterState();
            Debug.Log("Entering Patrol State");
            //enemyTank = enemy.GetComponent<NavMeshAgent>();
            Patrol();
        }
        public override void OnExitState()
        {
            base.OnExitState();
            Debug.Log("Exiting Patrol State");
        }
        public override void Update() 
        {   
            if(enemyTank.remainingDistance <= enemyTank.stoppingDistance)
            {
                IdleState();
            }
            Vector3 origin = enemy.transform.position;
            Collider[] Objs = Physics.OverlapSphere(origin, enemy.GetEnemyModel.DetectionRadius);
            for(int i = 0; i < Objs.Length; i++)
            {
                if(Objs[i].GetComponent<TankView>())
                {
                    var targetPos = Objs[i].gameObject.transform.position;
                    target = targetPos;
                    ChaseState();
                }
            }
        }
        void Patrol()
        {
            enemyTank.stoppingDistance = 0.5f;
            int i = Random.Range(0, enemy.GetEnemyModel.patrolPoints.Length-1);
            enemyTank.SetDestination(enemy.GetEnemyModel.patrolPoints[i]);
        }
        private void ChaseState()
        {
            enemy.ChangeState(new EnemyChaseState(enemy));
            nextState = new EnemyChaseState(enemy);
        }
        private void IdleState()
        {
            enemy.ChangeState(new EnemyIdleState(enemy));
            nextState = new EnemyIdleState(enemy);
        }
    }
}
