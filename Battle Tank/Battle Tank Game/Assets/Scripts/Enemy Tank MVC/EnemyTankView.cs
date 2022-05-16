using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    [HideInInspector]public EnemyTankController enemyTankController;
    [HideInInspector]public Transform playerTransform;
    public GameObject explosionPrefab;     
    internal AudioSource explosionAudio;
    internal ParticleSystem explosionParticles;

    public Rigidbody shell;
    public Transform fireTransform;
    public Slider healthSlider;
    public Image fillImage;

    public EnemyStatesMachine PatrolState;
    public EnemyStatesMachine ChaseState;
    public EnemyStatesMachine AttackState;

    [HideInInspector]public EnemyStatesMachine currentState;
    [HideInInspector]public State activeState;
    [SerializeField]private State initialState;

    public LayerMask whatIsGround; 
    public LayerMask whatIsPlayer;
    public NavMeshAgent agent;    
    public float walkPointRange, sightRange, attackRange;
    internal bool playerInSightRange, playerInAttackRange;
    internal bool alreadyAttacked;
    public bool walkPointSet;
    public float timeBetweenAttacks;
    [HideInInspector]public Vector3 walkPoint;


    void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    void Start()
    {   
        SetHealth();
        InitializeState();       
        // currentState = PatrolState;
        // currentState.OnStateEnter();
    }

    private void SetHealth()
    {
        enemyTankController.SetHealthUI();
    }

    private void FixedUpdate()
    {
        CheckPlayerInRange();
    }

    private void CheckPlayerInRange()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsGround);
    }

    public void SetEnemyTankController(EnemyTankController _enemyTankController)
    {
        enemyTankController = _enemyTankController;
    }    

    private void InitializeState()
    {
        switch (initialState)
        {
            case State.Patrol:
                {
                    currentState = PatrolState;
                    break;
                }
            case State.Chase:
                {
                    currentState = ChaseState;
                    break;
                }
            case State.Attack:
                {
                    currentState = AttackState;
                    break;
                }
            default:
                {
                    currentState = PatrolState;
                    break;
                }   
        }
        
        currentState.OnStateEnter();
    }

    public void FireShell()
    {
        float _currentLaunchForce = 15f;
        Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
        shellInstance.velocity = _currentLaunchForce * fireTransform.forward;          
    }
  
    public void Death()
    {
        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);

        explosionParticles.Play();
        explosionAudio.Play();

        Destroy(gameObject);
    }
}

