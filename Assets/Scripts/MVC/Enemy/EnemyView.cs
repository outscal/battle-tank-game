using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    //private float movement;
    //private float rotation;

    public EnemyType enemyType;
    public Rigidbody rb;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        enemyController.UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, enemyController.GetTarget()) < 1)
        {
            enemyController.IterateWayPointIndex();
            enemyController.UpdateDestination();
        }
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    
    // code for enemy patrol
}

// view = intercations
// model = data
// controller = logic for object