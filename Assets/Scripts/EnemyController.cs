using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : GenericSingletonClass<EnemyController>, IDamageable
{

    public Image fillImage;                                 // The image component of the slider.

    public float currentHealth;                      // How much health the tank currently has.
    public int patrolLevel;
    public int speed;

    public int enemyCounter;
    public bool isDead;                                // Has the tank been reduced beyond zero health yet?
    public int scoreCounter;


    public GameObject tankExplosion;

    override public void Awake()
    {
        // Instantiate the explosion prefab and get a reference to the particle system on it.
        //m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();

        // Get a reference to the audio source on the instantiated prefab.
        //m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        // Disable the prefab so it can be activated when it's required.
        //m_ExplosionParticles.gameObject.SetActive(false);

    }

    void Start()
    {

    }


    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        isDead = false;


        //hack to stop nullrefexcp
        if (fillImage == null) { return; }


        // Update the health slider's value.
        currentHealth = fillImage.fillAmount = 1f;

        fillImage.color = Color.green;



    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Shells")
        {
            IDamageable takeDamage = GetComponent<IDamageable>();

            if (takeDamage != null)
            {
                takeDamage.TakeDamage(0.5f);
            }
            GameManager.Instance.scoreCounter += 10;
        }


    }

    public void TakeDamage(float amount)
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

    public void Die()
    {
        // Set the flag so that this function is only called once.
        isDead = true;

        // Move the instantiated explosion prefab to the tank's position and turn it on.
        var tankExplosionGo = PoolManager.Instantiate(tankExplosion, transform.position, transform.rotation);
             

        // Play the particle system of the tank exploding.
        tankExplosionGo.GetComponent<ParticleSystem>().Play();

        // Play the tank explosion sound effect.
        tankExplosionGo.GetComponent<AudioSource>().Play();

        // Turn the tank off.
        //PoolManager.GetPool(Spawner.Instance.enemyGo);

        //m_ExplosionParticles.Stop();
        //Spawner.Instance.enemiesGo.Remove(gameObject);

        for (int i = 0; i < Spawner.Instance.enemyTankList.Count; i++)
        {
            //Check if GameObject is in the List
            if (Spawner.Instance.enemyTankList[i] == gameObject)
            {
                Destroy(gameObject);
            }
        }

        Spawner.Instance.counter++;

    }

    void Update()
    {
        //Debug.Log(scoreCounter);
    }


}
