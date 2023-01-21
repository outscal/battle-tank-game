using System.Collections;
using UnityEngine;

public class PlayerTankView : MonoBehaviour
{
    private new Renderer renderer;
    private PlayerTankService playerTankService;
    public Transform BulletSpawnPoint;
    public GameObject TankExplosion;
    public PlayerTankController playerTankController;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        playerTankService = GetComponent<PlayerTankService>();


        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 8f, -4f);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerTankController.Shoot(BulletSpawnPoint);
        }

    }

    public void TakeDamage(float damage)
    {
        playerTankController.playerModel.Health -= damage;

        // Update the color of the enemy based on its health
        if (playerTankController.playerModel.Health < 0)
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
        Debug.Log("Player has died.");
    }

    IEnumerator DestroyParticleEffect(GameObject particleEffect)
    {
        yield return new WaitForSeconds(5f); // wait for 5 seconds
        Destroy(particleEffect);
        Debug.LogWarning("Particle effect Destroyed");
    }

    public void SetPlayerTankController(PlayerTankController pTankController)
    {
        playerTankController = pTankController;
    }


    public void UpdateColor(Color color)
    {
        renderer.material.color = color;
    }

    public void UpdatePosition(Vector3 position)
    {
        transform.position = position;
    }

}