using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using BTManager;

namespace StateMachine
{
    public class GameMenuState : GameState
    {

        public AsyncOperation asyncOperation { get; private set; }

        string sceneName;

        public GameMenuState(string sceneName)
        {
            this.sceneName = sceneName;
        }

        public override void OnStateEnter()
        {
            //SceneManager.LoadSceneAsync(sceneName);
            asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;
        }

        public override void OnUpdate()
        {
            if (!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                    //gameStateType = GameStateTypeDefine();
                    //GameManager.Instance.SetGameState();
                }
            }
        }


        //protected override GameStateType GameStateTypeDefine()
        //{
        //    return GameStateType.Lobby;
        //}

    }
}