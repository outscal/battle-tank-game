using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Tank;
namespace Tanks.Tank
{
    public class EnemyAttackState : EnemyStates
    {
        private float timeElapsed;
        public EnemyAttackState (EnemyView _enemy)  : base(_enemy)
        {
            enemy = _enemy;
        }
        public override void OnEnterState()
        {
            base.OnEnterState();
            Debug.Log("Entering Attack State");
            enemyTank.stoppingDistance = enemy.GetEnemyModel.AttackRadius;
            //enemyController = _enemyController;
        }
        public override void OnExitState()
        {
            base.OnExitState();
            Debug.Log("Exiting Attack State");
        }
        public override void Update() 
        {
            Debug.Log("Update of Attack");
            timeElapsed += enemy.timeElapsed;

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
            //if(timeElapsed >= 1 && targetDistance <= enemy.GetEnemyModel.AttackRadius)
            if(timeElapsed >= 1 && enemyTank.remainingDistance <= enemyTank.stoppingDistance)
            {
                ShootSequence();
            }
            if(targetDistance > enemy.GetEnemyModel.AttackRadius && targetDistance <= enemy.GetEnemyModel.EngageRadius)
            //if (enemyTank.remainingDistance > enemyTank.stoppingDistance && enemyTank.remainingDistance <= enemy.GetEnemyModel.EngageRadius)
            {
                Debug.Log("Target Out of Fire Range");
                ChaseState();
            }
            if(targetDistance > enemy.GetEnemyModel.EngageRadius)
            //if (enemyTank.remainingDistance > enemy.GetEnemyModel.EngageRadius)
            {
                Debug.Log("Target Escaped");
                IdleState();
            }
            
        }
        void ShootSequence()
        {
            Debug.LogError("shooting");
            timeElapsed = 0;
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
