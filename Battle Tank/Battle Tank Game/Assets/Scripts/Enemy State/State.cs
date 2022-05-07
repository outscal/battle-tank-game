 using UnityEngine;

public abstract class State
{
    protected StateMachine Enemy;
    protected EnemyState stateName;

    public abstract void OnStateEnter(StateMachine Enemy);
    
    public abstract void OnStateExit(StateMachine Enemy);

    public abstract void Tick(StateMachine Enemy);
    
}

