namespace BattleTank.StateMachine
{
    public class BaseState
    {
        protected StateMachine stateMachine;

        public BaseState(StateMachine _stateMachine)
        {
            stateMachine = _stateMachine;
        }

        public virtual void Tick() { }
        public virtual void OnStateEnter() { }
    }
}