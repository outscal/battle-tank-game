using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine
{
    public class GameReplayState : GameState
    {

        public AsyncOperation asyncOperation { get; private set; }

        string sceneName;
        bool replayGame = false;

        public GameReplayState(string sceneName)
        {
            replayGame = false;
            this.sceneName = sceneName;
            //BTManager.GameManager.Instance.GameStarted
        }

        protected override GameStateType GameStateTypeDefine()
        {
            return GameStateType.Replay;
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

                if (replayGame == false)
                {
                    replayGame = true;
                    BTManager.GameManager.Instance.OnReplayGame();
                }
            }
        }
    }
}