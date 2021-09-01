using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    //[RequireComponent(typeof(EnemyTankView))]
    public class EnemyTankState : MonoBehaviour
    {
        public  EnemyTankView enemyTankView;
        public virtual void OnEnterState() 
        {
            this.enabled = true;
        }
        public virtual void OnExitState()
        {
            this.enabled = false;
        }
        //enemy will exit from one state and enter in anather state
        public void ChangeState(EnemyTankState newState)
        {
            if (enemyTankView.currentState != null)
            {
                enemyTankView.currentState.OnExitState();
            }

            enemyTankView.currentState = newState;
            enemyTankView.currentState.OnEnterState();
        }
    }
}