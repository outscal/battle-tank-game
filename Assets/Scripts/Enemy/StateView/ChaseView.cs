using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Manager;

namespace Enemy
{
    public class ChaseView : EnemyBaseStateView
    {

        [SerializeField] private EnemyView enemyView;

        public event Action<EnemyState> StateUpdate;

        protected override void OnEnable()
        {
            base.OnEnable();

            enemyView.PetrolState.enabled = false;
            transform.LookAt(enemyView.targetPos);

            if (Vector3.Distance(enemyView.targetPos,transform.position) > 15f)
            {
                enemyView.StateChangedMethod(EnemyState.petrol);
                this.enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Pause)
            {
                if (enemyView.Agent.isStopped == false)
                    enemyView.Agent.isStopped = true;

                return;
            }
            else if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Game)
            {
                if (enemyView.Agent.isStopped == true)
                    enemyView.Agent.isStopped = false;
            }

            if (Vector3.Distance(enemyView.targetPos, transform.position) <= 0.1f)
            {
                enemyView.StateChangedMethod(EnemyState.petrol);
                this.enabled = false;
            }
        }
    }
}