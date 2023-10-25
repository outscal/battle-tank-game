using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankPatrollingState : TankState
    {
        private float timneElapsed;

        protected override void Awake()
        {
            base.Awake();
            Debug.Log("Patrolling Awake ");
        }
        public override void OnEnterState()
        {
            base.OnEnterState();
            Debug.Log("Entering State : Patrolling");
            tankView.ChangeColor(color);
        }

        public override void OnExitState()
        {
            base.OnExitState();
            Debug.Log("Exiting State : Patrolling");
        }

        private void Update()
        {
            timneElapsed += Time.deltaTime;
            if (timneElapsed > 5f)
            {
                tankView.ChangeState(tankView.chasingingState);
            }
        }
    }
}