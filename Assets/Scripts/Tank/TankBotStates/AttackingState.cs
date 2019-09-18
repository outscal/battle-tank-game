using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class AttackingState : TankBotState
    {
        private TankController targetTank;
        public TankController TargetTank {set { targetTank = value; }}
        public override void OnEnterState(TankController _tankController, TankView _tankView)
        {
            base.OnEnterState(_tankController, _tankView);
        }

        public override void OnExitState()
        {
            base.OnExitState();
        }

        public void Update() 
        {
            if (targetTank != null && (Vector3.Distance(targetTank.GetTankPosition(), tankController.GetTankPosition()) < TankService.Instance.BotTankPropScriptableObject.AttackTriggerDistance))
            {
                tankController.LookTo(targetTank.GetTankPosition());
                tankController.FireBullet();
            }
            else
            {
                ChasingState chasingBehaviour = tankView.GetComponent<ChasingState>();
                chasingBehaviour.TargetTank = targetTank;
                tankController.SetTankBotState(chasingBehaviour);
            }
        }
    }
}
