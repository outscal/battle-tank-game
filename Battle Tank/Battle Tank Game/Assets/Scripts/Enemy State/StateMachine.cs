using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
        
    protected State currentState;
    public State IdleState = new Idle();
    public State PatrolState = new Patrol();
    public State AttackState = new Attack();
    public State ChaseState = new Chase();

    public bool IsPatrol = false;

    void Start()
    {
        currentState = IdleState;
        currentState.OnStateEnter(this);
    }
    
    void Update()
    {
        currentState.Tick(this);    
    }
    
    public void SetState(State _state)
    {
        this.currentState = _state;
        currentState.OnStateEnter(this);
    }    
}
