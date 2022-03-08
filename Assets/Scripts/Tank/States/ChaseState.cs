using UnityEngine;

namespace Tank.States
{
    public class ChaseState: State
    {
        #region Private Data members

        private PlayerTankView _target;

        #endregion

        #region Getters

        public PlayerTankView Target => _target;

        #endregion

        #region Setters

        public void SetTarget(PlayerTankView newTarget) => _target = newTarget;

        #endregion

        #region Unity Functions

        private void Update()
        {
            if (_target)
            {
                _tankView.NavMeshAgent.SetDestination(_target.transform.position);
                Vector3 distance = _target.transform.position - _tankView.transform.position;
                if (distance.magnitude <=
                    ((EnemyTankModel) _tankView.TankController.TankModel).AiAgentModel.AttackRange)
                    _tankView.AbleToAttack(_target);
            }
        }

        #endregion
    }
}