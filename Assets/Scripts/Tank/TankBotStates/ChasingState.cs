using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class ChasingState : TankBotState
    {
        private TankController targetTank;
        public TankController GetTargetTank() 
        {
            return targetTank;
        }

        public void SetTargetTank(TankController _controller) 
        {
            targetTank = _controller;
        }

        public void Update() 
        {
            if (targetTank != null && tankController.IsTargetTankInShootingRange(targetTank))
            {
                AttackingState attackingBehaviour = tankView.GetComponent<AttackingState>();
                attackingBehaviour.SetTargetTank(targetTank);
                tankController.ChangeState(attackingBehaviour);
            }
            else if (targetTank != null && tankController.IsTargetTankInDetectionRange(targetTank))
            {
                tankController.LookTo(targetTank.GetTankPosition());
                tankController.MoveTo(Vector3.MoveTowards(tankView.transform.position, targetTank.GetTankPosition(), Time.deltaTime));
            }
            else
            {
                tankController.ChangeState(tankView.GetComponent<PatrollingState>());
            }
        }
    }
}
