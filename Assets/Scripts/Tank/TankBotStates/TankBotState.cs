using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class TankBotState : MonoBehaviour
    {
        protected TankController tankController;
        public virtual void OnEnterState(TankController _tankController)
        {
            tankController = _tankController;
            this.enabled = true;
        }

        public virtual void OnExitState()
        {
            this.enabled = false;
        }
    }
}
