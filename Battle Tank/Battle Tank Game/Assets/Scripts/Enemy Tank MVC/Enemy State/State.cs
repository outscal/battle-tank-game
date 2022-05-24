 using UnityEngine;

public abstract class State
{
    public abstract void OnStateEnter(EnemyStatesMachine _EnemyStates);
    public abstract void OnUpdate(EnemyStatesMachine _EnemyStates);
    public abstract void OnStateExit(EnemyStatesMachine _EnemyStates);  
}

