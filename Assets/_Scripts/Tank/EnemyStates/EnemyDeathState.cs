using UnityEngine;
using Enemy.State;
using Enemy.View;

namespace Enemy.DeathState
{
    public class EnemyDeathState : EnemyTankState
    {
        public EnemyDeathState(EnemyView enemyView): base(enemyView) { }

        public override void Tick()
        {
            Debug.Log("Tick - Death State");
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Debug.Log("Entering Death State", enemyView);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("Exit Death State", enemyView);
        }
    }
}