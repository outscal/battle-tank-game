using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]private List<EnemyTankState> states = new List<EnemyTankState>();
    [SerializeField]private float m_proximityRadius;
    [SerializeField]private Transform m_target;

    private EnemyTankState m_currentState;
    private StateType m_activeStateOfTank=StateType.Patrol;
    private bool hasSeenTank=false;
    private float m_attackRadius;

    internal Vector3 startingPosition;
    private bool isAlive=true;
    private EnemyHealth enemyHealth;

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````
    private void Start() {
        enemyHealth = GetComponent<EnemyHealth>();
        m_attackRadius = m_proximityRadius/2;
        startingPosition = transform.position;
    }

    private void Update() {

        switch (m_activeStateOfTank)
        {
            case StateType.Patrol:
                ChangeState(states[0]);
                break;

            case StateType.Attack:
                ChangeState(states[1]);
                break;

            case StateType.Chase:
                
                ChangeState(states[2]);
                break;

            case StateType.MoveToStartPosition:
                ChangeState(states[3]);
                break;

            case StateType.None:
                Debug.Log("none");
                break;
        }
        
        FindOutState();                    
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private void ChangeState(EnemyTankState _state){
        if(m_currentState==null){
            m_currentState = _state;
            m_currentState.OnEnterState();
        }
        else{
             if(m_currentState!=_state){                    //if current state different from required
                m_currentState.OnExitState();
                m_currentState = _state;
                m_currentState.OnEnterState();
            }
        }

    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private void FindOutState(){
        if(!enemyHealth.IsDead){
            if(Vector3.Distance(m_target.position,transform.position) < m_proximityRadius){
                hasSeenTank = true;
                if (Vector3.Distance(m_target.position,transform.position) < m_attackRadius){                                      
                    m_activeStateOfTank = StateType.Attack;  
                }else{
                    m_activeStateOfTank = StateType.Chase;
                }
            }else{
                if(hasSeenTank){
                    m_activeStateOfTank = StateType.MoveToStartPosition;
                    hasSeenTank = false;
                }else{
                    m_activeStateOfTank = StateType.Patrol;
                }
            }        
        }
    }



//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    // internal void StartChasing(){
    //     if(Vector3.Distance(m_target.position,transform.position)<m_proximityRadius){
    //        m_activeStateOfTank = StateType.Chase; 
    //     }
    //     else{
    //         //continue in patrol
    //     }
    // }

    // internal void AttackPlayer(){

    // }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````




    private void OnDrawGizmos() {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, m_proximityRadius);

        //attackRadius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_proximityRadius/2);
        
    }
}
