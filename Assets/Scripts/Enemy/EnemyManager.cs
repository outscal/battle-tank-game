using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]private List<EnemyTankState> states = new List<EnemyTankState>();
    private EnemyTankState m_currentState=null;
    private StateType m_stateOfTank;

    private bool haveYouSeenPlayer=false;
    [SerializeField]private float m_proximityRadius;
    [SerializeField]private Transform m_target;

    [SerializeField]private Transform StartPosition;
    private bool goingHome;

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Start() {
        //m_stateOfTank = StateType.Patrol;
    }

    private void Update() {

        switch (m_stateOfTank)
        {
            case StateType.Patrol:
                Debug.Log("patrol");
                ChangeState(states[0]);
                break;

            case StateType.Attack:
                ChangeState(states[1]);
                break;

            case StateType.Chase:
                ChangeState(states[2]);
                break;

            case StateType.MoveToStartPosition:
                Debug.Log("moveto");
                ChangeState(states[3]);
                break;

            case StateType.Death:
                ChangeState(states[4]);
                break;
        }
        
        DetectPlayer();                    
    
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private void ChangeState(EnemyTankState _state){
        if(m_currentState==null){                           //if the current state is null then
            m_currentState = _state;
            m_currentState.OnEnterState();
        }
        else if(m_currentState!=_state){                    //if current state different from required
            m_currentState.OnExitState();
            m_currentState = _state;
            m_currentState.OnEnterState();
        }
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private void DetectPlayer(){                                                                   
        if(Vector3.Distance(transform.position, m_target.position) < m_proximityRadius){
            
            //m_stateOfTank = StateType.Attack;
            haveYouSeenPlayer = true;
        }
        else{
            Debug.Log("haveYouSeenPlayer"+haveYouSeenPlayer);
            if(haveYouSeenPlayer){
                Debug.Log("playerSeen");
                if(!(Vector3.Distance(transform.position,StartPosition.position)<0.2f)){
                    Debug.Log("tankAway");
                    m_stateOfTank = StateType.MoveToStartPosition;
                    haveYouSeenPlayer = false;
                }
            }

            m_stateOfTank = StateType.Patrol;
        }
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private void OnDrawGizmos() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_proximityRadius);
    }
}
