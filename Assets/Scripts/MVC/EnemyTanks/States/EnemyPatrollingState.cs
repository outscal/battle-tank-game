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
            enemyTankView.activeState = EnemyState.Patrolling;
            enemyTankView.enemyTankController.Patrol();
        }

        public override void OnExitState()
        {
            base.OnExitState();
        }
    }
}