using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;
using TankGame.Tank;
public class EnemyPatroling : EnemyState
{
    private float timeElapsed;
    private Coroutine coroutine;
    public GameObject chasingZone;
    private bool isPatroling;
    private EnemyStates currentState;
    private Vector3 patrolPosition;
    protected Vector3 enemyPos;  // not getting detected in attacking state
    private Vector3 newDirection;
    private Rigidbody rb;
    private float speed = 200f;
    private float resetTankTimer;
   

    public override void OnEnterState()
    {   
        base.OnEnterState();
        enemyPos = enemyView.transform.position;
        patrolPosition = new Vector3(Random.Range(enemyPos.x + 10, enemyPos.x - 10), enemyPos.y, Random.Range(enemyPos.z + 10, enemyPos.z - 10));
        //enemyView.SetTankColor(changedColor);
        currentState = EnemyStates.Patroling;
    }
   
    public override void OnExitState()
    {

        base.OnExitState();
    }

    private void FixedUpdate()
    {
        if (currentState == EnemyStates.Patroling)
        {
            //enemyView.moveTank();
            MoveTank();

        }
    }

    private void MoveTank()
    {
        resetTankTimer += Time.deltaTime;
        if (Vector3.Distance(enemyView.transform.position, patrolPosition) > 1 & resetTankTimer <5)
        {
            newDirection = patrolPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(newDirection);
            enemyView.transform.rotation = rotation;
            enemyView.rb.velocity = enemyView.transform.forward * 1 * Time.deltaTime * speed;
        }
        else
        {
            resetTankTimer = 0;
            enemyPos = enemyView.transform.position;
            patrolPosition = new Vector3(Random.Range(enemyPos.x +10 , enemyPos.x - 10), enemyPos.y, Random.Range(enemyPos.z + 10, enemyPos.z - 10));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TankView>())
        {
            enemyView.ChangeState(enemyView.chasingState);
            currentState = EnemyStates.Chasing;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TankView>())
        {
            enemyView.ChangeState(enemyView.patrolingState);
            currentState = EnemyStates.Patroling;
        }
    }
}
