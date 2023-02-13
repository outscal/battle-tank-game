using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Tank;
public class EnemyView : MonoBehaviour, IDamagable
{
    private Rigidbody rb;
    private BoxCollider coll;
    private EnemyController enemyController;
    public BulletSpawner bulletSpawner;
    public float timeElapsed;
    [SerializeField] private LayerMask surroundMask;
    public LayerMask tankMask;
    private EnemyStates currentState;
    private void Start() 
    {
        currentState = new EnemyIdleState(this);
        currentState.OnEnterState();
    } 
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    public EnemyModel GetEnemyModel
    {
        get
        {
            return enemyController.GetEnemyModel();
        }
        
    }
    private void Update() 
    {
        
        timeElapsed = Time.deltaTime;
        currentState.Update();
    }
    public void GetDamage(float damage)
    {
        enemyController.GetDamage(damage);
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemyController.GetEnemyModel().DetectionRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyController.GetEnemyModel().EngageRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyController.GetEnemyModel().AttackRadius);
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
    public void ChangeState(EnemyStates newState)
    {
        if(currentState != null)
        {
            currentState.OnExitState();
        }
        currentState = newState;
        currentState.OnEnterState();
    }
}
