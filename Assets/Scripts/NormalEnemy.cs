using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class NormalEnemy : MonoBehaviour, IDamageable
{
    Animator anim;
    public GameObject player;
    private GameObject shellGo;

    public Transform fireTransform;
    public GameObject shellPrefab;
    public GameObject tankExplosion;
    public Image fillImage;                                 // The image component of the slider.

    public TankConfig tankConfig;
    public GameObject dustTrails;


    IEnumerator DelayExplosion()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    public virtual void Fire()
    {
        shellGo = PoolManager.Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);
        Rigidbody shellRb = shellGo.GetComponent<Rigidbody>();
        shellRb.velocity = fireTransform.forward * tankConfig.fireForce;
    }

    public virtual void StopFiring()
    {
        CancelInvoke("Fire");
    }
    public virtual void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, tankConfig.numberOfShellsPerSeconds);
    }

    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        player = GameManager.Instance.playerTank;
        CheckOutOfBounds();
        tankConfig.isDead = false;
    }

    public virtual void Die()
    {
        // Move the instantiated explosion prefab to the tank's position and turn it on.
        var tankExplosionGo = PoolManager.Instantiate(tankExplosion, transform.position, transform.rotation);
        // Play the particle system of the tank exploding.
        tankExplosionGo.GetComponent<ParticleSystem>().Play();
        // Play the tank explosion sound effect.
        tankExplosionGo.GetComponent<AudioSource>().Play();

        anim.SetBool("isDead", true);

        tankConfig.isDead = true;

        StartCoroutine(DelayExplosion());
        EnemySpawner.Instance.enemyCounter--;
        EnemySpawner.Instance.allEnemyTankList.Remove(gameObject);
    }

    public virtual void Update()
    {
        if (tankConfig.isDead) {
            anim.SetFloat("distance", 0f);
        }
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
        dustTrails.transform.GetComponent<ParticleSystem>().Play();

    }

    public virtual void CheckOutOfBounds()
    {
        if (gameObject.transform.position.y > 2 || gameObject.transform.position.y < -2) { Destroy(gameObject); }
    }
    public virtual void OnDestroy()
    {
        //rb = GetComponent<Rigidbody>();
    }

    public virtual void OnEnable()
    {
        //hack to stop nullrefexcp
        if (fillImage == null) { return; }

        // Update the health slider's value.
        tankConfig.health = fillImage.fillAmount;

        fillImage.color = Color.green;

    }

    public virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Shells")
        {
            IDamageable takeDamage = GetComponent<IDamageable>();

            if (takeDamage != null)
            {
                takeDamage.TakeDamage(tankConfig.damage);
            }
            GameManager.scoreCounter += tankConfig.score;
        }


    }

    public virtual void TakeDamage(float damage)
    {
        // Reduce current health by the amount of damage done.
        tankConfig.health -= damage;

        // Change the UI elements appropriately.
        fillImage.fillAmount = tankConfig.health;

        if (tankConfig.health < 0.25f) { fillImage.color = Color.red; }

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (tankConfig.health <= 0f)
        {
            Die();
        }
    }


}

