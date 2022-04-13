using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    public GameObject Turret;
    public GameObject BulletEmitter;
    public float turretRotationRate;
    public float fireTime;
    public Slider healthSlider;
    public Image healthFillImage;
    public Color maxHealthColour = Color.green;
    public Color minHealthColour = Color.red;
    public GameObject explosionPrefab;
    public bool isEnemyTankLive = false;
    public AudioSource explosionSound;
    public ParticleSystem explosionParticles;
    public LayerMask groundMask, playerTank;
    public NavMeshAgent navMeshAgent;
    public Vector3 walkPoint;
    public float walkPointRange;
    public bool walkPointSet;
    public float sightRange;
    public float attackrange;
    public bool playerInSightRange;
    public bool playerInAttackRange;
    public Transform tankPlayer;
    public bool isAttacked;
    public EnemyTankController enemyTankController;
    [HideInInspector]
    public EnemyStates currentState;
    [SerializeField]
    private EnemyStates activeState;
    public EnemyPatrolling patrollingState;
    public EnemyChasing chasingState;
    public EnemyAttacking attackingState;


    private void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionSound = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
        GetPlayerTransform();
    }
    void Start()
    {
        ChangeState(activeState);
    }
    private void Update()
    {
        enemyTankController.EnemyTankRange();
    }

    public void DestroyEnemyTank()
    {

        Destroy(gameObject);
    }

    //getting tnakplayer transform value
    public void GetPlayerTransform()
    {
        if (TankService.Instance.tankView)
            tankPlayer = TankService.Instance.tankView.transform;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damage)
    {
        enemyTankController.TakeDamage(damage);
    }
    //using to change state in State machine
    public void ChangeState(EnemyStates newState)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }
        currentState = newState;
        currentState.OnEnterState();
    }

}

