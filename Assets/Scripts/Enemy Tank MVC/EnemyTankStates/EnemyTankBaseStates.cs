using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyTankServices
{
    // Template class for creating different states of enemy tank.
    [RequireComponent(typeof(EnemyTankView))]
    public class EnemyTankBaseStates : MonoBehaviour
    {
        protected EnemyTankView enemyTankView;
        protected EnemyTankModel enemyTankModel;

        protected virtual void Awake()
        {
            enemyTankView = GetComponent<EnemyTankView>();
        }

        protected virtual void Start()
        {
            enemyTankModel = enemyTankView.enemyTankController.enemyTankModel;
        }

        // Enables the behaviour of that state. 
        public virtual void OnStateEnter()
        {
            this.enabled = true;
        }

        // Disables the behaviour of that state.
        public virtual void OnStateExit()
        {
            this.enabled = false;
        }

        // To change enemy tank state from current to new state.
        public void ChangeState(EnemyTankBaseStates newState)
        {
            if (enemyTankView.currentState != null)
            {
                enemyTankView.currentState.OnStateExit();
            }

            enemyTankView.currentState = newState;
            enemyTankView.currentState.OnStateEnter();
        }
    }
}
