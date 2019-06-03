using UnityEngine.SceneManagement;
using UnityEngine;
using BTManager;
using System.Collections;

namespace StateMachine
{
    public class GameLoadingState : GameState
    {
        public AsyncOperation asyncOperation { get; private set; }

        string sceneName;

        public GameLoadingState(string sceneName)
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
            if(!asyncOperation.isDone)
            {
                if(asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                    //gameStateType = GameStateTypeDefine();
                }
            }
        }

        //public override void OnStateExit()
        //{
        //    base.OnStateExit();
        //}

        //protected override GameStateType GameStateTypeDefine()
        //{
        //    return GameStateType.Loading;
        //}


    }
}