using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTManager;

namespace StateMachine
{
    public class GamePauseState : GameState
    {
        public override void OnStateEnter()
        {
            GameManager.Instance.PauseGame();
        }

        protected override GameStateType GameStateTypeDefine()
        {
            return GameStateType.Pause;
        }

        public override void OnStateExit()
        {
            GameManager.Instance.UnPauseGame();
        }

    }
}