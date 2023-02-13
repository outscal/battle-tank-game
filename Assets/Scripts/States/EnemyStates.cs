using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Tanks.Tank
{
    [RequireComponent(typeof(EnemyView))]
    public abstract class EnemyStates
    {
        protected EnemyView enemy;
        protected NavMeshAgent enemyTank
        {
            get
            {
                return enemy.GetComponent<NavMeshAgent>();
            }
        }
        protected EnemyStates nextState;
		
        protected Vector3 target;
        protected bool PlayerDetected = false;
        protected StateMachine state;
        protected StateEvent Event;
        
        public EnemyStates(EnemyView _enemy)
        {
            enemy = _enemy;
        }
        public virtual void OnEnterState()
        {}
        public abstract void Update();
        public virtual void OnExitState()
        {}
    } 
}


