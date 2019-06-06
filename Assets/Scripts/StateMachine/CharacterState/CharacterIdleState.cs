using Player;
using UnityEngine;

namespace StateMachine
{
    public class CharacterIdleState : CharacterState
    {
        public override void OnStateEnter()
        {
            Debug.Log("[CharacterIdleState] IdleState: OnStart");   
        }

        public override void OnStateExit()
        {
            Debug.Log("[CharacterIdleState] IdleState: OnExit");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

    }
}