using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyFollow : EnemyState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyView.activeState = EnemyStateEnum.Follow;
            enemyView.enemyController.Follow();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}
