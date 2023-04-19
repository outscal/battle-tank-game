using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyView : MonoBehaviour, IDamagable
{
    private Rigidbody rb;
    private BoxCollider coll;
    private EnemyController enemyController;
    public Transform bulletSpawner;
    [SerializeField] private LayerMask surroundMask;
    public LayerMask tankMask;
    public StateMachine<EnemyView> stateMachine;
    private StateInterface<EnemyView> currentState;
    private void Awake() 
    {
        stateMachine = new StateMachine<EnemyView>(this);
        currentState = new EnemyIdleState();
        stateMachine.ChangeState(currentState);
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
        stateMachine.Update();
    }
    public void GetDamage(float damage, TypeDamagable type)
    {
        enemyController.GetDamage(damage,type);
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemyController.GetEnemyModel().DetectionRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyController.GetEnemyModel().EngageRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyController.GetEnemyModel().AttackRadius);
    }
}
