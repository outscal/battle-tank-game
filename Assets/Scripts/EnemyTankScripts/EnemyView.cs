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
    public Transform GetGun()
    {
        return gun;
    }
    public NavMeshAgent GetAgent()
    {
        return agent;
    }
    public int GetEnemyStrength()
    {
        return enemyController.GetStrength();
    }
    public float GetEnemyVisibilityRange()
    {
        return enemyController.GetVisibilityRange();
    }
    public float GetEnemyDetectionRange()
    {
        return enemyController.GetDetectionRange();
    }
    public float GetEnemyBPM()
    {
        return enemyController.GetBulletsPerMinute();
    }
    public float GetEnemySpeed()
    {
        return enemyController.GetSpeed();
    }
    public float GetEnemyRotationSpeed()
    {
        return enemyController.GetRotationSpeed();
    }
    public void TakeDamage(int damage)
    {
        enemyController.TakeDamage(damage);
    }
    public void EnemyShootBullet()
    {
        enemyController.Shoot(gun);
    }
    public Transform GetPlayerTransform()
    {
        return enemyController.GetPlayerTransform();
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
    void Update()
    {
        currentState.Tick();
    }
}
