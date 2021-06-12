using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private enum State
    {
        Roaming,
        ChaseTarget,
        ShootingTarget,
        GoingBackToStart,
    }

    [SerializeField] Rigidbody m_Shell;
    [SerializeField] Transform m_FireTransform;
    [SerializeField] float m_MinLaunchForce = 15f;

    private float m_CurrentLaunchForce;
    private bool m_Fired;
    private State state;
    
    

    private void Awake()
    {
        state = State.Roaming;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //State Machine
        switch (state)
        {
            default:
            case State.Roaming:
            break;

            //if its in chase range
            case State.ChaseTarget:

            //if its in fire range
            Fire();
             
            //if its Too far, stop chasing
            state = State.GoingBackToStart;
            break;

            case State.ShootingTarget:
            break;

            case State.GoingBackToStart:
            state = State.Roaming;
            break;
        }
    }

    private void Fire()
    {
        m_Fired = true;

        Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; ;

        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}
