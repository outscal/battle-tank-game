using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Tank;
using UnityEngine.AI;
namespace Tanks.Tank
{
    public class EnemyChaseState : EnemyStates
    {
        
        private float timeElapsed;
        public EnemyChaseState (EnemyView _enemy)  : base(_enemy)
        {
            enemy = _enemy;
        }
        public override void OnEnterState()
        {
            base.OnEnterState();
            Debug.Log("Entering Chase State");
            //enemyTank = enemy.GetComponent<NavMeshAgent>();
            Chase();
        }
        public override void OnExitState()
        {
            base.OnExitState();
            Debug.Log("Exiting Chase State");
        }
        public override void Update() 
        {
            Vector3 origin = enemy.transform.position;
            Collider[] Objs = Physics.OverlapSphere(origin, enemy.GetEnemyModel.EngageRadius);
            for(int i = 0; i < Objs.Length; i++)
            {
                if(Objs[i].GetComponent<TankView>())
                {
                    target = Objs[i].gameObject.transform.position;
                }
            }
            float targetDistance = Vector3.Distance(enemy.transform.position, target);
            if(targetDistance <= enemy.GetEnemyModel.AttackRadius)
            //if(enemyTank.remainingDistance <= enemyTank.stoppingDistance)
            {
                AttackState();
            }
            //if(targetDistance > enemy.GetEnemyModel.AttackRadius && targetDistance <= enemy.GetEnemyModel.EngageRadius)
            //if (enemyTank.remainingDistance > enemy.GetEnemyModel.AttackRadius && enemyTank.remainingDistance <= enemy.GetEnemyModel.EngageRadius)
            //{
                //Chase();
            //}
            if(targetDistance > enemy.GetEnemyModel.EngageRadius)
            //if (enemyTank.remainingDistance > enemy.GetEnemyModel.EngageRadius)
            {
                IdleState();
            }
        }
        void Chase()//(Transform target)
        {
            enemyTank.stoppingDistance = enemy.GetEnemyModel.AttackRadius;
            enemyTank.destination = target;
            //Vector3 newDirection = Vector3.RotateTowards(enemy.transform.forward, target - enemy.transform.position, 0.5f, 0.0f);
            //enemy.transform.rotation = Quaternion.LookRotation(newDirection);
        }
        private void IdleState()
        {
            enemy.ChangeState(new EnemyIdleState(enemy));
            nextState = new EnemyIdleState(enemy);
        }
        private void AttackState()
        {
            enemy.ChangeState(new EnemyAttackState(enemy));
            nextState = new EnemyAttackState(enemy);
        }
        private void ChaseState()
        {
            enemy.ChangeState(new EnemyChaseState(enemy));
            nextState = new EnemyChaseState(enemy);
        }
    }

}
