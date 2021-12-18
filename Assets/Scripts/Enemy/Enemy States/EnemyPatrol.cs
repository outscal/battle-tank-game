using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyPatrol : EnemyState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyView.activeState = EnemyStateEnum.Patrol;
        }

        public void Update()
        {
            enemyView.enemyController.Patrol();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}
