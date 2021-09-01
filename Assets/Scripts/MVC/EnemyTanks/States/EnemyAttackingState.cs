using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// enemy attacking stste class.
    /// when player gets in range of enemy tank.
    /// enemy tank will fire bullet.
    /// </summary>
    public class EnemyAttackingState : EnemyTankState
    {
        //enemy eneters into attacking state
        public override void OnEnterState()
        {
            base.OnEnterState();
            enemyTankView.activeState = EnemyState.Attacking;
        }
        //enemy exits from attacking state
        public override void OnExitState()
        {
            base.OnExitState();
        }
        //
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                enemyTankView.navMeshAgent.isStopped = true;
                enemyTankView.navMeshAgent.ResetPath();
                enemyTankView.ChangeState(this);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                Vector3 lookDir = other.transform.position - enemyTankView.transform.position;
                if (lookDir != new Vector3(0, 0, 0))
                    RotateTowardsTarget();

            }
        }

        private void RotateTowardsTarget()
        {
           enemyTankView.transform.LookAt(enemyTankView.GetTankTransform());
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                enemyTankView.ChangeState(enemyTankView.chasingState);
            }
        }
    }
}
