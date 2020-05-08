using UnityEngine;
using Enemy.State;
using Enemy.View;

namespace Enemy.ChasingState
{
    public class EnemyChasingState : EnemyTankState
    {
        public EnemyChasingState(EnemyView enemyView): base(enemyView) { }

        public override void Tick()
        {
            Debug.Log("Tick - Chasing");
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Debug.Log("Entered Chasing state", enemyView);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("Exit Chasing state", enemyView);
        }
    }
}