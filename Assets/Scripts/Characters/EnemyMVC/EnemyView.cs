using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tanks.tank;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range; //radius of sphere
    public new ParticleSystem particleSystem;
    [SerializeField]
    private float PSDelay;
    private float playerSqrDistance;
    [SerializeField]
    private float chaseSqrRadius = 900f;
    [SerializeField]
    private float attackSqrRadius = 100f;
    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    private TankView player;
    private BulletServices bulletServices;

    private EnemyStates currentState;
    private EnemyIdleState idleState;
    private EnemyPatrolling patrolState;
    private EnemyAttackState attackState;
    private EnemyChaseState chaseState;
    private EnemyController _EnemyController;
    public Transform shootPoint;

    void Start()
    {
        idleState = new EnemyIdleState();
        patrolState=new EnemyPatrolling();
        attackState=new EnemyAttackState();
        chaseState=new EnemyChaseState();
        EnemyisMoving = true;
        currentState = patrolState;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TankView>();
    }
    public TankView GetTankView()
    {
        return player;
    }

    void Update()
    {
        currentState.OnUpdateState();
        if (EnemyisMoving)
        {
            //Patrol();
        }
        
    }
    private void CheckStateChanges()
    {
        playerSqrDistance = (this.transform.position - player.transform.position).sqrMagnitude;

        if (playerSqrDistance < attackSqrRadius)
        {
            if (currentState.GetState() != Enemystate.AttackState)
                ChangeState(attackState);
        }
        else if (playerSqrDistance < chaseSqrRadius)
        {
            if (currentState.GetState() != Enemystate.ChaseState)
                ChangeState(chaseState);
        }
        else
        {
            if (currentState.GetState() != Enemystate.PatrolState)
                ChangeState(patrolState);
        }
    }
    private void ChangeState(EnemyStates enemyStates)
    {
        currentState.OnExitState();
        currentState= enemyStates;
        Debug.Log("Current EnemyState :" + currentState.GetState().ToString());
        currentState.OnEnterState();


    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


    public bool EnemyisMoving { get; private set; }

    public void SetEnemyController(EnemyController enemyController)
        {
            _EnemyController = enemyController;
        }

    public IEnumerator Death()
    {
        particleSystem.Play();
        agent.SetDestination(transform.position);
        EnemyisMoving = false;
        yield return new WaitForSeconds(PSDelay);
        //particle effect
        Destroy(this.gameObject);
    }
    public void Patrol()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (_EnemyController.RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }
    }

    public void SetPatrolPosition(Transform patrolPosition, int patrolRadius)
    {
        centrePoint =this.gameObject.transform;
        range= patrolRadius;
    }

    public EnemyController GetEnemyController()
    {
        return _EnemyController;
    }

    public void shoot()
    {
       bulletServices.Shoot(shootPoint,this.gameObject);
    }

    public void Chase(Vector3 playerPos,float speed)
    {
        Vector3 enemypos=transform.position;
        Vector3 newEnemyPos = Vector3.MoveTowards(enemypos, playerPos, speed * Time.deltaTime);
        transform.LookAt(playerPos);
        transform.position = newEnemyPos;
    }
}
