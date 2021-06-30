using Assets.Scripts.Tank;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    public class EnemyIdle : MonoBehaviour
    {
        [SerializeField] Color m_TankColor = Color.blue;
        [SerializeField] float m_lookRadius = 10f;
        [SerializeField] Rigidbody m_Shell;
        [SerializeField] Transform m_FireTransform;
        [SerializeField] float m_MinLaunchForce = 30f;
        


        Transform Target;
        private float m_CurrentLaunchForce;


        private bool m_Fired;
        public float delay = 1f;

        private float TimerForNextAttack;
        private float Cooldown;


        // Use this for initialization
        void Start()
        {
            Target = TankManager.instance.m_tank.transform;

            Cooldown = 1;
            TimerForNextAttack = Cooldown;
            m_Fired = false;

            
        }
        void Update()
        {
            float Distance = Vector3.Distance(Target.position, transform.position);


            if (Distance <= m_lookRadius)
            {

                //attack the target
                //-----Method------------------------------

                //if there is a game object
                if (GameObject.Find("Tank"))
                {

                    if (TimerForNextAttack > 0)
                    {
                        TimerForNextAttack -= Time.deltaTime;
                    }
                    else if (TimerForNextAttack <= 0)
                    {
                        Fire();
                        TimerForNextAttack = Cooldown;
                    }
                }

                // if there is no game object
                else
                {
                    m_Fired = false;
                }
                //------------end method-------------------

                // face the target
                faceTarget();
            }
            
        }

        void faceTarget()
        {
            Vector3 direction = (Target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, m_lookRadius);
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