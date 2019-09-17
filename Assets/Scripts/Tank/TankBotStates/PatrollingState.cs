using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class PatrollingState : TankBotState
    {
        private Vector3 currentTargetPos;
        public override void OnEnterState(TankController _tankController, TankView _tankView)
        {
            base.OnEnterState(_tankController, _tankView);
            SetNewTargetPosition();
        }

        public override void OnExitState()
        {
            base.OnExitState();
        }

        private void SetNewTargetPosition()
        {
            currentTargetPos =  TankBattleUtilities.GetAPointInRange(-10, 10, 0, 0, -10, 10);
            tankController.LookTo(currentTargetPos);
        }

        private void Update() 
        {
            Vector3 currentPosition = tankView.transform.position;
            if(currentPosition != currentTargetPos)
            {
                tankController.MoveTo(Vector3.MoveTowards(currentPosition, currentTargetPos, Time.deltaTime));
            }
            else
            {
                SetNewTargetPosition();
            }
        }
    }
}
