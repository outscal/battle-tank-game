using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : GenericSingletonClass<EnemyController>, IDamageable
{

    public float m_StartingHealth = 100f;               // The amount of health each tank starts with.
    public Image m_FillImage;                           // The image component of the slider.
    public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
    public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.
    //public GameObject m_ExplosionPrefab;                // A prefab that will be instantiated in Awake, then used whenever the tank dies.


    //private AudioSource m_ExplosionAudio;               // The audio source to play when the tank explodes.
    //public ParticleSystem m_ExplosionParticles;        // The particle system the will play when the tank is destroyed.
    public float currentHealth;                      // How much health the tank currently has.
    public bool isDead;                                // Has the tank been reduced beyond zero health yet?

    public int patrolLevel;
    public int speed;

    //public GameObject shells;

    //public Transform fireTransform;

    //public float fireForce = 2000;

    public int enemyCounter;

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
        currentHealth = m_StartingHealth;
        isDead = false;

        // Update the health slider's value and color.
        SetHealthUI();

    }

    public void SetHealthUI()
    {
        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, currentHealth / m_StartingHealth);
    }


    private void OnCollisionEnter(Collision collision)
    {
        IDamageable takeDamage = GetComponent<IDamageable>();

        if (takeDamage != null)
            takeDamage.TakeDamage(20f);
        else
            Debug.Log(takeDamage);
        //TakeDamage(20f);
    }

    public void TakeDamage(float amount)
    {

        // Reduce current health by the amount of damage done.
        currentHealth -= amount;

        // Change the UI elements appropriately.
        SetHealthUI();

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
        //m_ExplosionParticles.transform.position = transform.position;
        //m_ExplosionParticles.gameObject.SetActive(true);

        // Play the particle system of the tank exploding.
        //m_ExplosionParticles.Play();

        // Play the tank explosion sound effect.
        //m_ExplosionAudio.Play();

        // Turn the tank off.
        Destroy(gameObject);

        //m_ExplosionParticles.Stop();
        Spawner.Instance.enemyTankNumber--;

        Spawner.Instance.counter++;

    }

    void Update()
    {
        //Debug.Log(enemyCounter);
    }

}
