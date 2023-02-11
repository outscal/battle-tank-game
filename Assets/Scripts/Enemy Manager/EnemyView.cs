using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour, IDamagable
{
    private Rigidbody rb;
    private BoxCollider coll;
    private EnemyController enemyController;
    public BulletSpawner bulletSpawner;
    [SerializeField] private LayerMask surroundMask;
    [SerializeField] private LayerMask tankMask;
    private Vector3 cubeSize;
    private float sphereRadius = 15f;
    private float maxDistance = 0f;
    private bool PlayerDetected = false;
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
        rb = this.GetComponent<Rigidbody>();
        // coll = this.GetComponent<BoxCollider>();
        if(enemyController == null)
        {
            Debug.LogError("nullreff");
        }
    }
    public void GetDamage(float damage)
    {
        enemyController.GetDamage(damage);
    }
    private void Update() 
    {
        Collider[] objs =  Physics.OverlapSphere(transform.position,sphereRadius,tankMask);
            Debug.Log("Colliders detected");
            for(int i = 0; i < objs.Length; i++)
            {
                if(objs[i].GetComponent<TankView>())
                {
                    PlayerDetected = true;
                    Debug.Log("Player detected");
                    Transform target = objs[i].gameObject.transform;
                    enemyController.MoveToPlayer(target);
                }
            }
        if(!PlayerDetected)
        {
            enemyController.Move();
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,sphereRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,5f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,15f);
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
