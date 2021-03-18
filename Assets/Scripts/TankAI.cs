using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;
    private GameObject player;
    public Transform fireTransform;
    public GameObject shellInstance;
    private GameObject shellGo;
    public Image fillImage;                                 // The image component of the slider.
    public GameObject tankExplosion;


    public float fireForce;
    public float interval;
    public static float currentHealth;                      // How much health the tank currently has.
    public static float playersDamage;
    public static int enemyScore;

    public static bool isDead;                                // Has the tank been reduced beyond zero health yet?


    public GameObject GetPlayer() { return player; }

    public virtual void Fire(float fireForce)
    {
        shellGo = PoolManager.Instantiate(shellInstance, fireTransform.position, fireTransform.rotation);
        Rigidbody shellRb = shellGo.GetComponent<Rigidbody>();
        shellRb.velocity = fireTransform.forward * fireForce;
    }

    public virtual void StopFiring()
    {
        CancelInvoke("Fire");
    }
    public virtual void StartFiring(float interval)
    {
        InvokeRepeating("Fire", 0.5f, interval);
    }

    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        player = GameManager.Instance.playerTank;
        PoolManager.SetNetPoolSize(shellInstance, 10);
        PoolManager.SetPoolSize(shellInstance, 5);

        fireTransform = gameObject.FindInChildren("Fire").GetComponent<Transform>();
        fillImage = Resources.Load("healthbar") as Image;
    }

    public virtual void Die()
    {
        anim.SetBool("isDead", true);

        // Set the flag so that this function is only called once.
        isDead = true;

        // Move the instantiated explosion prefab to the tank's position and turn it on.
        var tankExplosionGo = PoolManager.Instantiate(tankExplosion, transform.position, transform.rotation);


        // Play the particle system of the tank exploding.
        tankExplosionGo.GetComponent<ParticleSystem>().Play();

        // Play the tank explosion sound effect.
        tankExplosionGo.GetComponent<AudioSource>().Play();


        for (int i = 0; i < EnemySpawner.Instance.allEnemyTankList.Count; i++)
        {
            //Check if GameObject is in the List
            if (EnemySpawner.Instance.allEnemyTankList[i] == gameObject)
            {
                Destroy(gameObject);
            }
        }

        EnemySpawner.Instance.enemyCounter--;
    }

    protected virtual void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));

        if (isDead)
        {
            Die();
        }
    }


    public virtual void OnEnable()
    {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        isDead = false;

        //hack to stop nullrefexcp
        if (fillImage == null) { return; }

        // Update the health slider's value.
        currentHealth = fillImage.fillAmount = 1f;

        fillImage.color = Color.green;

    }

    public virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Shells")
        {
            IDamageable takeDamage = GetComponent<IDamageable>();

            if (takeDamage != null)
            {
                takeDamage.TakeDamage(playersDamage);
            }
            GameManager.scoreCounter += enemyScore;
        }


    }

    public virtual void TakeDamage(float amount)
    {

        // Reduce current health by the amount of damage done.
        currentHealth -= amount;

        // Change the UI elements appropriately.
        fillImage.fillAmount = currentHealth;

        if (currentHealth < 0.25f) { fillImage.color = Color.red; }

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (currentHealth <= 0f && !isDead)
        {
            Die();
        }
    }


}



public class MediumEnemy : TankAI
{


    public MediumEnemySpawnManagerScriptableObject mediumSpawnManagerValues;
    public override void Start()
    {
        base.Start();

        Debug.Log("MEdium" + fireTransform);
    }
    public override void Fire(float fireForce)
    {

        base.Fire(mediumSpawnManagerValues.fireForce);

    }

}
public class HardEnemy : TankAI
{


    public HardEnemySpawnManagerScriptableObject hardSpawnManagerValues;

    public override void Start()
    {
        base.Start();
    }
    public override void Fire(float fireForce)
    {
        base.Fire(hardSpawnManagerValues.fireForce);
    }


}