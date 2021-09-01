using System.Collections;
using UnityEngine;


namespace Outscal.BattleTank
{
    public class EnemyChasingState : EnemyTankState
    {
        //private EnemyTankView enemyTankView;
        public override void OnEnterState()
        {
            base.OnEnterState();
            enemyTankView.activeState = EnemyState.Chasing;
            enemyTankView.enemyTankController.ChaseToPlayer();
        }
        public override void OnExitState()
        {
            base.OnExitState();
        }
    }
}