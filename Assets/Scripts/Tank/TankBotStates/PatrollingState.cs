using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class PatrollingState : TankBotState
    {
        private Vector3 currentTargetPos;
        public override void OnEnterState(TankController _tankController)
        {
            base.OnEnterState(_tankController);
            SetNewTargetPosition();
        }

        public override void OnExitState()
        {
            base.OnExitState();
        }

        private void SetNewTargetPosition()
        {
            currentTargetPos =  TankBattleUtilities.GetAPointInRange(-10, 10, 0, 0, -10, 10);
            this.transform.rotation = Quaternion.LookRotation(currentTargetPos);
        }

        public void Update() 
        {
            if(this.transform.position != currentTargetPos)
            {
                this.transform.rotation = Quaternion.LookRotation(currentTargetPos);
                this.transform.position = Vector3.MoveTowards(this.transform.position, currentTargetPos, 1*Time.deltaTime);
            }
            else
            {
                SetNewTargetPosition();
            }
        }
    }
}
