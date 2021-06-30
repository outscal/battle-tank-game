using Assets.Scripts.Tank;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolling : MonoBehaviour
    {
    [SerializeField] Color m_TankColor = Color.blue;
    [SerializeField] float m_lookRadius = 10f;
    [SerializeField] Rigidbody m_Shell;
    [SerializeField] Transform m_FireTransform;
    [SerializeField] float m_MinLaunchForce = 30f;

    Transform Target;
    private float m_CurrentLaunchForce;
    private bool m_Fired;
    private float TimerForNextAttack;
    private float Cooldown;

    //pattrolling
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    // Use this for initialization
    void Start()
    {
        Target = TankManager.instance.m_tank.transform;

        Cooldown = 1;
        TimerForNextAttack = Cooldown;
        m_Fired = false;

        //-----------for patrolling
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextPoint();

    }
    void Update()
    {
        float Distance = Vector3.Distance(Target.position, transform.position);


        if (Distance <= m_lookRadius)
        {
            AttackTarget();
            faceTarget(); 
        }
        //-----for patrolling
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

        
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

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
}