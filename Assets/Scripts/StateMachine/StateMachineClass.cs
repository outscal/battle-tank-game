namespace StateMachine
{
    public abstract class StateMachineClass
    {
        public virtual void OnStateEnter(){}
        public virtual void OnStateExit(){}
        public virtual void OnUpdate(){}
    }
}