using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class AttackingState : TankBotState
    {
        private TankController targetTank;
        public void SetTargetTank(TankController _controller)
        {
            targetTank = _controller;
        }

        public void Update() 
        {
            if (targetTank != null && tankController.IsTargetTankInShootingRange(targetTank))
            {
                tankController.LookTo(targetTank.GetTankPosition());
                tankController.FireBullet();
            }
            else
            {
                ChasingState chasingBehaviour = tankView.GetComponent<ChasingState>();
                chasingBehaviour.SetTargetTank(targetTank);
                tankController.ChangeState(chasingBehaviour);
            }
        }
    }
}
