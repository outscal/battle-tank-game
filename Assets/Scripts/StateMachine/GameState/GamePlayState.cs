using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace StateMachine
{
    public class GamePlayState: GameState
    {
        public AsyncOperation asyncOperation { get; private set; }

        string sceneName;
        bool gameStarted = false;

        public GamePlayState(string sceneName)
        {
            gameStarted = false;
            this.sceneName = sceneName;
            //BTManager.GameManager.Instance.GameStarted
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

                }
            }
            else if (asyncOperation.isDone)
            {
                if (gameStarted == false)
                {
                    gameStarted = true;
                    BTManager.GameManager.Instance.OnGameStarted();
                }
            }
        }

        //public override void OnStateExit()
        //{
        //    base.OnStateExit();
        //}

        //protected override GameStateType GameStateTypeDefine()
        //{
        //    return GameStateType.Game;
        //}

    }
}