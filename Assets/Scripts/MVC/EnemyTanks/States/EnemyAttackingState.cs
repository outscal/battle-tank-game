using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// enemy attacking stste class.
    /// when player gets in range of enemy tank.
    /// enemy tank will fire bullet.
    /// </summary>
    public class EnemyAttackingState : EnemyTankState
    {
        //enemy eneters into attacking state
        public override void OnEnterState()
        {
            base.OnEnterState();
            enemyTankView.activeState = EnemyState.Attacking;
            
        }
        //enemy exits from attacking state
        public override void OnExitState()
        {
            base.OnExitState();
        }
    }
}
