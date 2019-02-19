using Interfaces;
using Manager;

namespace StateMachine
{
    public class GamePauseState : GameState
    {
        private IGameManager gameManager;

        public override void OnStateEnter()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            gameManager.PauseGame();
        }

        protected override GameStateType GameStateTypeDefine()
        {
            return GameStateType.Pause;
        }

        public override void OnStateExit()
        {
            gameManager.UnPauseGame();
        }

    }
}