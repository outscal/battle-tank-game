using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Tank;
namespace Tanks.Tank
{
    public class EnemyIdleState : EnemyStates
    {
        private float timeElapsed = 0f;
        public EnemyIdleState (EnemyView _enemy) : base(_enemy)
        {
            enemy = _enemy;
        }
        public override void OnEnterState()
        {
            base.OnEnterState();
            Debug.Log("Entering Idle State");
            timeElapsed = 0f;
        }
        public override void OnExitState()
        {
            base.OnExitState();
            Debug.Log("Exiting Idle State");
        }
        public override void Update() 
        {
            Debug.Log("Idle State Update Called");
            timeElapsed += enemy.timeElapsed;
            
            if(timeElapsed >= 1)
                Debug.Log(timeElapsed);
                PatrolState();
        }
        private void ChaseState()
        {
            enemy.ChangeState(new EnemyChaseState(enemy));
            nextState = new EnemyChaseState(enemy);
            Event = StateEvent.Exit;
        }
        private void PatrolState()
        {
            enemy.ChangeState(new EnemyPatrolState(enemy));
            nextState = new EnemyPatrolState(enemy);
            Event = StateEvent.Exit;
        }
    }
}
