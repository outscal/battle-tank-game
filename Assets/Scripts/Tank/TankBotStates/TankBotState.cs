using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class TankBotState : MonoBehaviour
    {
        protected TankController tankController;
        protected TankView tankView;
        public virtual void OnEnterState(TankController _tankController, TankView _tankView)
        {
            tankController = _tankController;
            tankView = _tankView;
            this.enabled = true;
        }

        public virtual void OnExitState()
        {
            this.enabled = false;
        }
    }
}
