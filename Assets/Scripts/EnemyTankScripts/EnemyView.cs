using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour, IDamageable
{
    EnemyController enemyController;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform gun;
    [SerializeField] NavMeshAgent agent;
    EnemyState currentState;
    [SerializeField] public EnemyAttackState enemyAttackState;
    [SerializeField] public EnemyChaseState enemyChaseState;
    [SerializeField] public EnemyIdleState enemyIdleState;
    [SerializeField] public EnemyPatrolState enemyPatrolState;
    void Start()
    {
        ChangeState(enemyIdleState);
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    public NavMeshAgent GetAgent()
    {
        return agent;
    }
    public int GetEnemyStrength()
    {
        return enemyController.GetStrength();
    }
    public void TakeDamage(int damage)
    {
        enemyController.TakeDamage(damage);
    }
    public void ChangeState(EnemyState newState)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = newState;
        currentState.OnStateEnter();
    }
    public void SetEnemyAgentValues()
    {
        enemyController.SetAgentValues();
    }
    public void EnemyPatrol()
    {
        enemyController.Patrol();
    }
    void Update()
    {
        currentState.Tick();
    }
}
