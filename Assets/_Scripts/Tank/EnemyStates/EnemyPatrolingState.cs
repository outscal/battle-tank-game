using Enemy.State;
using Enemy.View;
using UnityEngine;

namespace Enemy.PatrolingState
{
    public class EnemyPatrolingState : EnemyTankState
    {
        public EnemyPatrolingState(EnemyView enemyView): base(enemyView) { }

        public override void Tick()
        {
            //what to do every frame in this state.
            Debug.Log("Tick - patroling");
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Debug.Log("Entered Patroling state", enemyView);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("Exiting Patroling state", enemyView);
        }
    }
}