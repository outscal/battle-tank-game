using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider coll;
    private EnemyController enemyController;
    public BulletSpawner bulletSpawner;
    [SerializeField] private LayerMask surroundMask;
    [SerializeField] private LayerMask tankMask;
    private Vector3 cubeSize;
    private float sphereRadius = 10f;
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
    private void Update() {
        // cubeSize = coll.bounds.size;
        // if(!Physics.BoxCast(transform.position + new Vector3(0f,0.4f,0f) , cubeSize + new Vector3(0,-0.5f,0f), transform.forward, transform.rotation, 2f))
        // {
        //     enemyController.Move();
        //     Debug.DrawRay(transform.position, transform.forward * 1f, Color.green);
        // }
        // else
        // {
        //     enemyController.Turn();
        //     Debug.DrawRay(transform.position, transform.forward * 1f, Color.red);
        // }

        Collider[] objs =  Physics.OverlapSphere(transform.position,sphereRadius,tankMask);
        {Debug.Log("Collider detected");
            for(int i = 0; i < objs.Length; i++)
            {
                if(objs[i].GetComponent<TankView>())
                {
                    PlayerDetected = true;
                    Debug.Log("tankdetected");
                    Transform target = objs[i].gameObject.transform;
                    enemyController.MoveToPlayer(target);
                }
                else
                {
                    PlayerDetected = false;
                }
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
        Gizmos.DrawWireCube(transform.position + new Vector3(0f,0.4f,0f) , cubeSize + new Vector3(0,-0.5f,0f));
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + new Vector3(0f,0.4f,0f) + transform.forward* 2f, cubeSize + new Vector3(0,-0.5f,0f));
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
