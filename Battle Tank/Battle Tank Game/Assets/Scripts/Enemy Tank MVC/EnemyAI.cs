using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agnet;
    public TankView player;
    public LayerMask whatIsGround, whatIsPlayer;
    //patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    //attack
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Transform fireTransform;
    public Rigidbody shell;

    public float Health;
    
    private void Starts()
    {
        Intialization();
    }

    private void Update()
    {
        CheckPlayerInRange();
    }

    private void Intialization()
    {
        player = GameObject.FindObjectOfType<TankView>();
        agnet = GetComponent<NavMeshAgent>();
    }

    private void CheckPlayerInRange()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if(playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if(playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patroling()
    {
        if(!walkPointSet)
            SearchWalkPoint();

        if(walkPointSet)
            agnet.SetDestination(walkPoint);
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached 
        if(distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agnet.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {
        agnet.SetDestination(transform.position);
        transform.LookAt(player.transform);

        if(!alreadyAttacked)
        {
            float _currentLaunchForce = 15f;
            //attack code is here
            Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
            shellInstance.velocity = _currentLaunchForce * fireTransform.forward;

            // shootingAudio.clip = fireClip;
            // shootingAudio.Play();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnColliderEnter(Collider other)
    {
        if(other.tag == "Shell")
        {
            TakeDamage(30);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        Debug.Log("Health = " + Health);

        if(Health <= 0) 
            Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
