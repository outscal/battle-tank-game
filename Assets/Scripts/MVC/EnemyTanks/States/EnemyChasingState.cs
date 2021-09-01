using System.Collections;
using UnityEngine;


namespace Outscal.BattleTank
{
    public class EnemyChasingState : EnemyTankState
    {
        //private EnemyTankView enemyTankView;
        public override void OnEnterState()
        {
            base.OnEnterState();
            enemyTankView.activeState = EnemyState.Attacking;
        }
        public override void OnExitState()
        {
            base.OnExitState();
        }
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
                enemyTankView.enemyTankController.CreatingBullet();
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