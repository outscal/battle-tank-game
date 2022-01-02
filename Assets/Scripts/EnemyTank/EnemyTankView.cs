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


    private void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionSound = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);

        UpdateAwake();
    }
    void Start()
    {
        Debug.Log("Enemy Tank Created");

    }
    public void DestroyEnemyTank()
    {

        Destroy(gameObject);
    }

    public void DestroyGameObjects()
    {
        DestroyPlayer();
    }

    private async void DestroyPlayer()
    {
        //await new WaitForSeconds(2f);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<TankView>().tankController.OnDeath();

    }

    public void UpdateAwake()
    {
        tankPlayer = TankService.Instance.tankView.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
}