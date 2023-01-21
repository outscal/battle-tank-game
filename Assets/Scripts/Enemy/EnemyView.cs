using System;
using System.Collections;
using UnityEngine;


public class EnemyView : MonoBehaviour
{

    private new Renderer renderer;
    public EnemyController enemyController;
    public float timeBetweenShots;
    public float timeSinceLastShot;
    public GameObject TankExplosion;
    public Transform BulletSpawnPoint;
    public Coroutine ShootingCoroutine;
    public float shootDelay;
    public float ChaseDistance;
    public float TimeToWaitNextBulletSpawn;

    private void Start()
    {
        renderer = GetComponent<Renderer>();

    }

    private void Update()
    {
        if (Vector3.Distance(enemyController.playerTank.transform.position, transform.position) <= ChaseDistance)
        {
            if(ShootingCoroutine == null)
                ShootingCoroutine = StartCoroutine(Shoot(BulletSpawnPoint));
        }
    }

    public IEnumerator Shoot(Transform spawnPoint)
    {
        while (true)
        {
            // Check if the player is nearby
            if (Vector3.Distance(enemyController.playerTank.transform.position, transform.position) <= ChaseDistance)
            {
                // Check if enough time has passed since the last shot
                if (timeSinceLastShot >= timeBetweenShots)
                {
                    // Wait for 10 seconds before spawning the next bullet
                    yield return new WaitForSeconds(TimeToWaitNextBulletSpawn);

                    // Code to SpawnBullet
                    BulletService.Instance.SpawnBullet(spawnPoint, spawnPoint.transform.rotation, false);

                    // Reset the time since last shot
                    timeSinceLastShot = 0;
                    yield return new WaitForSeconds(shootDelay);
                }
                else
                {
                    // Add to the time since last shot
                    timeSinceLastShot += Time.deltaTime;
                }
            }
            yield return null;
        }
    }


    public void FixedUpdate()
    {
        enemyController?.MoveTowardsPlayer();


    }

    public void UpdateColor(Color color)
    {
        renderer.material.color = color;
    }

    public void TakeDamage(float damage)
    {
        enemyController.enemymodel.Health -= damage;

        // Update the color of the enemy based on its health
        if (enemyController.enemymodel.Health < 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (TankExplosion != null)
        {
            GameObject explosion = Instantiate(TankExplosion, transform.position, Quaternion.identity);
            explosion.GetComponent<ParticleSystem>().Play();

            // Start the coroutine to destroy the particle effect
            StartCoroutine(DestroyParticleEffect(explosion));
        }
        else
        {
            Debug.LogError("TankExplosion is null, please check if it is properly set");
        }
        Destroy(gameObject);
        Debug.Log(enemyController.EnemyTankType + "This enemy type has died.");
    }




    IEnumerator DestroyParticleEffect(GameObject particleEffect)
    {
        yield return new WaitForSeconds(5f); // wait for 5 seconds
        Destroy(particleEffect);
        Debug.LogWarning("Particle effect Destroyed");
    }

    public void SetEnemyTankController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
}



