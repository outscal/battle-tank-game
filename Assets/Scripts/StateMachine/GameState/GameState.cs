using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BTManager;

namespace StateMachine
{
    //public enum GameStateType { Loading, Lobby, Game, GameOver }

    public class GameState : StateMachineClass
    {
        //public GameStateType gameStateType = GameStateType.Loading;

        public GameState()
        {
            //gameStateType = GameStateTypeDefine();
        }

        //protected virtual GameStateType GameStateTypeDefine()
        //{
        //    return GameStateType.Loading;
        //}

        public override void OnStateExit()
        {
            //gameStateType = GameStateTypeDefine();
        }

    }
}