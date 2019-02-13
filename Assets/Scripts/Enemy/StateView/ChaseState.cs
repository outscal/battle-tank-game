using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BTManager;

namespace Enemy
{
    public class ChaseState : EnemyBaseStateView
    {

        [SerializeField] private EnemyView enemyView;

        public event Action<EnemyState> StateUpdate;

        protected override void OnEnable()
        {
            //Debug.Log(this.name + " is in ChaseState");
            transform.LookAt(enemyView.targetPos);

            if (Vector3.Distance(enemyView.targetPos,transform.position) > 15f)
            {
                //StateUpdate?.Invoke(EnemyState.petrol);
                enemyView.StateChangedMethod(EnemyState.petrol);
                this.enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Pause) return;

            if (Vector3.Distance(enemyView.targetPos, transform.position) <= 0.1f)
            {
                //Debug.Log("Go to Petrol Mode");
                enemyView.StateChangedMethod(EnemyState.petrol);
                //StateUpdate?.Invoke(EnemyState.petrol);
                this.enabled = false;
            }
            else
            {
                transform.Translate(0, 0, 2f * Time.deltaTime);
            }
        }
    }
}