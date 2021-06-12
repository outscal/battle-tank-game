using Assets.Scripts.Tank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    public class EnemyChasing : MonoBehaviour
    {
        [SerializeField] float m_lookRadius = 10f;
        [SerializeField] Rigidbody m_Shell;
        [SerializeField] Transform m_FireTransform;
        [SerializeField] float m_MinLaunchForce = 15f;
        [SerializeField] float m_StartDelay = 3f;
        [SerializeField] float m_EndDelay = 3f;

        
        Transform Target;
        NavMeshAgent m_Agent;

        private float m_CurrentLaunchForce;
        private WaitForSeconds m_StartWait;
        private WaitForSeconds m_EndWait;

        // Use this for initialization
        void Start()
        {
            Target = TankManager.instance.m_tank.transform;
            m_Agent = GetComponent<NavMeshAgent>();

            
            m_StartWait = new WaitForSeconds(m_StartDelay);
            m_EndWait = new WaitForSeconds(m_EndDelay);
            //StartCoroutine(GameLoop());

        }
        void Update()
        {
                float Distance = Vector3.Distance(Target.position, transform.position);

           
            if(Distance <= m_lookRadius)
            {
                m_Agent.SetDestination(Target.position);

                if(Distance <= m_Agent.stoppingDistance)
                {
                    //attack the target
                    //StartCoroutine(GameLoop()); //not working so quoted

                    // face the target
                    faceTarget();
                }
            }
        }

        void faceTarget()
        {
            Vector3 direction = (Target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, m_lookRadius);
        }

        /*
        //coroutene not proper
        private IEnumerator GameLoop()
        {
            yield return StartCoroutine(RoundStarting());
            Fire();
            yield return StartCoroutine(RoundEnding());
        }

        private IEnumerator RoundStarting()
        {
            yield return m_StartWait;
        }

        private IEnumerator RoundEnding()
        {
            yield return m_EndWait;
        }
       
        
        private void Fire()
        {
            Rigidbody shellInstance =
                Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

            shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; ;

            m_CurrentLaunchForce = m_MinLaunchForce;
        }
        */
    }
}