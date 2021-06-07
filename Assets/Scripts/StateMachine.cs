using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State State;

    public void setState(State state)
    {
        State = state;
        //StartCoroutine(State.Idle());

    }

}

