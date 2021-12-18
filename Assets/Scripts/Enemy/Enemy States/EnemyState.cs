using EnemyServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyState : MonoBehaviour
    {
        public EnemyView enemyView;

        public virtual void OnStateEnter()
        {
            this.enabled = true;
        }

        public virtual void OnStateExit()
        {
            this.enabled = false;
        }

        public void changeState(EnemyState newState)
        {
            if(enemyView.currentState != null)
            {
                enemyView.currentState.OnStateExit();
            }
            enemyView.currentState = newState;
            enemyView.currentState.OnStateEnter();
        }
    }
}
