using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State currentState;

    public void SetState(State state) {
        currentState = state;
    }

    public State GetCurrentState() {
        return currentState;
    }
}
