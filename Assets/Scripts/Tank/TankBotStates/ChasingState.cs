using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class ChasingState : TankBotState
    {
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
            
        }
    }
}
