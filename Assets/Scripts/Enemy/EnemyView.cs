using UnityEngine;
using EnemyStates;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour, IDamagable
{
    public NavMeshAgent NavMeshAgent { get {  return m_NavMeshAgent; } }
    public float Damage { get { return EnemyController.GetEnemyModel().Damage; } }
    public float FireRate { get { return EnemyController.GetEnemyModel().FireRate; } }
    public float EnemyAttackRange { get { return EnemyController.GetEnemyModel().AttackRange; } }
    public float MaxHealth { get { return EnemyController.GetEnemyModel().MaxHealth; } }
    public float Health { get { return EnemyController.GetEnemyModel().Health; } }
    public LayerMask ShellLayer { get { return EnemyController.GetEnemyModel().ShellLayer; } }
    
    private EnemyController EnemyController { get; set; }
    private EnemyState m_CurrentState;
    private NavMeshAgent m_NavMeshAgent;

    [System.Serializable]
    private enum State
    {
        Idle,
        Patrol,
        Chase,
        Attack
    }
    private State m_CurrentStateEnum;

    private float m_IdleTime = 0f, m_TimeToSwitchToPatrol = 2f;

    // Implement visual aspects of the enemy here
    private void Start()
    {
        Debug.Log("Enemy view created!");
        AssetManager.Instance.AddEnemyView(this);
        if (m_NavMeshAgent = GetComponent<NavMeshAgent>())
        { 
            m_NavMeshAgent.speed = EnemyController.GetEnemyModel().Speed;
            m_NavMeshAgent.angularSpeed = EnemyController.GetEnemyModel().TurnSpeed;
        }

        // Default State = Idle
        SetState(new IdleState(this));
    }

    private void Update()
    {
        if(m_CurrentStateEnum == State.Idle) 
        {
            m_IdleTime += Time.deltaTime;
            if(m_IdleTime >= m_TimeToSwitchToPatrol)
            { 
                // Switch to Patrol state.
                SetState(new PatrolState(this));
                m_IdleTime = 0f;
            }
        }
        m_CurrentState.Tick();
    }

    public void SetState(EnemyState newState)
    {
        m_CurrentState?.OnStateExit();
        m_CurrentState = newState;
        m_CurrentStateEnum = StateToStateEnum(newState);
        m_CurrentState.OnStateEnter();
    }

    private State StateToStateEnum(EnemyState newState)
    {
        if (newState is IdleState)
            return State.Idle;
        else if (newState is PatrolState)
            return State.Patrol;
        else if (newState is ChaseState)
            return State.Chase;
        else
            return State.Attack;
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        EnemyController = _enemyController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        TankView tankView;
        if (tankView = collision.gameObject.GetComponent<TankView>())
        {
            // Apply damage to Tank & Take Damage from tank.
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

            // Tank takes damage.
            damagable.TakeDamage(EnemyController.GetEnemyModel().Damage);

            // Enemy takes damage.
            TakeDamage(tankView.GetDamage);
        }
    }

    public bool PlayerInDetectionRange()
    {
        Vector3 playerPosition = AssetManager.Instance.TankView?.transform.position ?? Vector3.zero;
        EnemyModel enemyModel = EnemyController.GetEnemyModel();

        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        if (distanceToPlayer <= enemyModel.DetectionRadius)
        {
            Vector3 directionToPlayer = (playerPosition - transform.position).normalized;
            float angleBetweenEnemyAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (angleBetweenEnemyAndPlayer < enemyModel.FieldOfView * 0.5f)
            {
                return true;
            }
        }
        return false;
    }

    public bool PlayerInAttackRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, AssetManager.Instance.TankView?.transform.position ?? Vector3.zero);
        return distanceToPlayer <= EnemyController.GetEnemyModel().AttackRange;
    }

    public bool TakeDamage(float damage)
    {
        return EnemyController.TakeDamage(damage);
    }

    public bool GiveDamage(IDamagable damagable)
    {
        return EnemyController.GiveDamage(damagable);
    }

    public void DestroyEnemy()
    {
        EnemyController.DestroyEnemy();
    }
}
