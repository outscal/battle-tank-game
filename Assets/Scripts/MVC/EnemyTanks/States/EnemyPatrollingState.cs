using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank 
{ /// <summary>
/// 
/// </summary>
    public class EnemyPatrollingState : EnemyTankState
    {
        public override void OnEnterState()
        {
            base.OnEnterState();
            enemyTankView.enemyTankController.EnemyPatrollingAI();
        }
        //private void Update()
        //{
        //    enemyTankView.enemyTankController.EnemyPatrollingAI();
        //}

        public override void OnExitState()
        {
            base.OnExitState();
        }
    }
}