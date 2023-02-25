using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider coll;
    private EnemyController enemyController;
    public BulletSpawner bulletSpawner;
    [SerializeField] private LayerMask layerMask;
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
        rb = this.GetComponent<Rigidbody>();
        coll = this.GetComponent<BoxCollider>();
        if(enemyController == null)
        {
            Debug.LogError("nullreff");
        }
    }
    public void GetDamage(float damage)
    {
        enemyController.GetDamage(damage);
    }
    private void Update() {
        if(!Physics.BoxCast(new Vector3(0f,0.1f,0.5f) , new Vector3(1.5f,0.5f,1), transform.forward, Quaternion.identity, 1f))
        {
            enemyController.Move();
            Debug.DrawRay(transform.position, transform.forward * 1f, Color.green);
        }
        else
        {
            enemyController.Turn();
            Debug.DrawRay(transform.position, transform.forward * 1f, Color.red);
        }
        if(Physics.SphereCast(transform.position,10f ,transform.forward,out RaycastHit hitInfo,10f, layerMask))
        {
            enemyController.Fire();
        }
    }
}
