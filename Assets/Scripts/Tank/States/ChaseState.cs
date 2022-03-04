using System;
using UnityEngine;

namespace Tank.States
{
    public class ChaseState: State
    {
        private PlayerTankView _target;

        public PlayerTankView Target => _target;
        public void SetTarget(PlayerTankView newTarget) => _target = newTarget;

        

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
    }
}