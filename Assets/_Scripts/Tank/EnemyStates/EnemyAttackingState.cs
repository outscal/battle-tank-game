using UnityEngine;
using Enemy.State;
using Enemy.View;

namespace Enemy.AttackingState
{
    public class EnemyAttackingState : EnemyTankState
    {
        public EnemyAttackingState(EnemyView enemyView): base(enemyView) { }

        public override void Tick()
        {
            Debug.Log("Tick - Attacking");
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Debug.Log("Entering Attacking State", enemyView);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("Exit Attacking State", enemyView);
        }
    }
}