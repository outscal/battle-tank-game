using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    private PlayerTank playerTank;
    public float howClose;
    private float maxX, maxZ, minX, minZ;
    public float patrolTime = 5f;
    public float timer = 0f;
    private float patrollingRadius = 30;
    public float canFire = 0f;
    public float fireRate = 5f;
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    private BoxCollider boxCollider;

    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        boxCollider = GroundBoxCollider.groundboxCollider;
        player = PlayerTank.playerTransform;
        maxX = boxCollider.bounds.max.x;
        maxZ = boxCollider.bounds.max.z;
        minX = boxCollider.bounds.min.x;
        minZ = boxCollider.bounds.min.z;
        Patrol();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= howClose)
        {
            transform.LookAt(player);
            enemy.SetDestination(player.position);
            Shoot();
        }
        else
        {
            Patrol();
        }
    }

    public Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        Vector3 randDir = new Vector3(x, 0, z);
        return randDir;
    }

    private void SetPatrolingDestination()
    {
        Vector3 newDestination = GetRandomPosition();
        enemy.SetDestination(newDestination);
    }

    public void Patrol()
    {
        timer += Time.deltaTime;
        if (timer > patrolTime)
        {
            SetPatrolingDestination();
            timer = 0;
        }
    }

    void Shoot()
    {
        canFire += Time.deltaTime;
        if (canFire > fireRate)
        {
            canFire = 0;
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firepoint.forward * bulletForce, ForceMode.Impulse);
        }
    }

}//class


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class EnemyFollow : MonoBehaviour
// {
//     public NavMeshAgent enemy;
//     public Transform player;
//     private float distance;
//     public float howClose;

//     public float canFire = 0f;
//     public float fireRate = 5f;
//     public Transform firepoint;
//     public GameObject bulletPrefab;
//     public float bulletForce = 10f;

//     private void Update()
//     {
//         distance = Vector3.Distance(player.position, transform.position);

//         if (distance <= howClose)
//         {
//             transform.LookAt(player);
//             enemy.SetDestination(player.position);
//             Shoot();
//         }

//         // // For melee attack or explosive
//         // if (distance < 15)
//         // {
//         //     // do damage or explode
//         //     Shoot();
//         // }
//     }

//     void Shoot()
//     {
//         canFire += Time.deltaTime;
//         if (canFire > fireRate)
//         {
//             canFire = 0;
//             GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
//             Rigidbody rb = bullet.GetComponent<Rigidbody>();
//             rb.AddForce(firepoint.forward * bulletForce, ForceMode.Impulse);
//         }
//     }
// }
