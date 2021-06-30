using Assets.Scripts.Tank;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    public class EnemyChasing : MonoBehaviour
    {
        [SerializeField] Color m_TankColor = Color.blue;
        [SerializeField] float m_lookRadius = 10f;
        
        [SerializeField] Rigidbody m_Shell;
        [SerializeField] Transform m_FireTransform;
        [SerializeField] Slider m_AimSlider;
        [SerializeField] float m_MinLaunchForce = 30f;
        [SerializeField] float m_MaxLaunchForce = 40f;
        [SerializeField] float m_MaxChargeTime = 0.75f;


        private float m_CurrentLaunchForce;
        private float m_ChargeSpeed;
        private bool m_Fired;

        private float TimerForNextAttack;
        private float Cooldown;


        Renderer rend;
        Transform Target;
        NavMeshAgent m_Agent;

        private void OnEnable()
        {
            //reseting the launch force and the UI
            m_CurrentLaunchForce = m_MinLaunchForce;
            m_AimSlider.value = m_MinLaunchForce;
        }

        void Start()
        {
            Target = TankManager.instance.m_tank.transform;
            m_Agent = GetComponent<NavMeshAgent>();

            m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
            Cooldown = 1;
            TimerForNextAttack = Cooldown;
            m_Fired = false;

            //coloring the tank 
            rend = GetComponent<Renderer>();
        }
        void Update()
        {
            rend.material.SetColor("_Color", m_TankColor);
              float Distance = Vector3.Distance(Target.position, transform.position);

           
            if(Distance <= m_lookRadius)
            {
               //chasing the playertank
                m_Agent.SetDestination(Target.position);

                if(Distance <= m_Agent.stoppingDistance)
                {
                    AttackTarget();
                    faceTarget();
                }
            }
            
        }

        private void AttackTarget()
        {
            //if there is a game object
            if (GameObject.Find("Tank") && TimerForNextAttack > 0)
            {
                TimerForNextAttack -= Time.deltaTime;
            }

            else if (GameObject.Find("Tank") && TimerForNextAttack <= 0)
            {
                Fire();
                TimerForNextAttack = Cooldown;
            }

            // if there is no game object
            else
            {
                m_Fired = false;
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

        private void attack()
        {
            m_AimSlider.value = m_MinLaunchForce;

            if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
            {
                m_CurrentLaunchForce = m_MaxLaunchForce;
                Fire();
            }


            else if (!m_Fired)
            {
                m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

                m_AimSlider.value = m_CurrentLaunchForce;
                Fire();
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
}