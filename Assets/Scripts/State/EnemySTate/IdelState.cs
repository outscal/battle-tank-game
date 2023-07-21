using BattleTank;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank.Tank
{
    public class IdelState : StateBase
    {
         private  EnemyController enemy;

        public IdelState(EnemyController enemy) : base(enemy)
        {
            stateName = STATE.IDLE;
        }
        public override void OnEnter()
        {
            base.OnEnter();
        }
        public override void OnUpdate()
        {
            if (IsPlayerInChaseRange())
            {
                MoveToChaseState();
                return;
            }
            if (IsEnemyAwayFromSpawn())
            {
               
            }
        }

        private bool IsEnemyAwayFromSpawn()
        {
            throw new NotImplementedException();
        }

        private void MoveToChaseState()
        {
            throw new NotImplementedException();
        }

        private bool IsPlayerInChaseRange()
        {
            throw new NotImplementedException();
        }
    }

}