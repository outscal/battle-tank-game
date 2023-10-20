using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankChasingState : TankState
    {
        [SerializeField]
        private Color differentColor;

        public override void OnEnterState()
        {
            base.OnEnterState();
            tankView.ChangeColor(differentColor);
        }

    }
}