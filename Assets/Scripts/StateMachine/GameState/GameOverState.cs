using UI;

namespace StateMachine
{
    public class GameOverState : GameState
    {
        public override void OnStateEnter()
        {
            GameUI.InstanceClass.GameOver();
        }

        protected override GameStateType GameStateTypeDefine()
        {
            return GameStateType.GameOver;
        }
    }
}