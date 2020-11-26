using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]private List<EnemyTankState> states = new List<EnemyTankState>();

    private EnemyTankState m_currentState;

    private void Start() {
        ChangeState(states[0]);
    }

    private void ChangeState(EnemyTankState _state){

        if(m_currentState!=null){
            m_currentState.OnExitState();
        }
        m_currentState = _state;
        m_currentState.OnEnterState();
    }

}
