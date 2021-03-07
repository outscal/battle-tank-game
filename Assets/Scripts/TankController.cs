using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class TankController : GenericSingletonClass<TankController>
{
    public int m_PlayerNumber = 1;              // Used to identify which tank belongs to which player.  This is set by this tank's manager.
    public float m_Speed = 12f;                 // How fast the tank moves forward and back.
    public float m_TurnSpeed = 180f;            // How fast the tank turns in degrees per second.
    public AudioSource m_MovementAudio;         // Reference to the audio source used to play engine sounds. NB: different to the shooting audio source.
    public AudioClip m_EngineIdling;            // Audio to play when the tank isn't moving.
    public AudioClip m_EngineDriving;           // Audio to play when the tank is moving.
    public float m_PitchRange = 0.2f;           // The amount by which the pitch of the engine noises can vary.


    private string m_MovementAxisName;          // The name of the input axis for moving forward and back.
    private string m_TurnAxisName;              // The name of the input axis for turning.
                          
    private float m_MovementInputValue;         // The current value of the movement input.
    private float m_TurnInputValue;             // The current value of the turn input.
    private float m_OriginalPitch;              // The pitch of the audio source at the start of the scene.

    private Rigidbody rb;                       // Reference used to move the tank.

    public GameObject shells;
    public Transform fireTransform;
    public float fireForce = 2000;

    public float m_StartingHealth = 100f;               // The amount of health each tank starts with.
    public Image m_FillImage;                           // The image component of the slider.
    public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
    public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.
    public GameObject m_ExplosionPrefab;                // A prefab that will be instantiated in Awake, then used whenever the tank dies.


    //private AudioSource m_ExplosionAudio;               // The audio source to play when the tank explodes.
    public ParticleSystem m_ExplosionParticles;        // The particle system the will play when the tank is destroyed.
    private float m_CurrentHealth;                      // How much health the tank currently has.
    public bool m_Dead;                                // Has the tank been reduced beyond zero health yet?


    override public void Awake()
    {
        // Instantiate the explosion prefab and get a reference to the particle system on it.
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();

        // Get a reference to the audio source on the instantiated prefab.
        //m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        // Disable the prefab so it can be activated when it's required.
        m_ExplosionParticles.gameObject.SetActive(false);

        rb = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        // Update the health slider's value and color.
        SetHealthUI();

        // Also reset the input values.
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    public void TakeDamage(float amount)
    {
        // Reduce current health by the amount of damage done.
        m_CurrentHealth -= amount;

        // Change the UI elements appropriately.
        SetHealthUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            OnDeath();
        }
    }


    private void SetHealthUI()
    {
        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }


    private void OnDeath()
    {
        // Set the flag so that this function is only called once.
        m_Dead = true;

        // Move the instantiated explosion prefab to the tank's position and turn it on.
        //m_ExplosionParticles.transform.position = transform.position;
        //m_ExplosionParticles.gameObject.SetActive(true);

        // Play the particle system of the tank exploding.
        //m_ExplosionParticles.Play();

        // Play the tank explosion sound effect.
        //m_ExplosionAudio.Play();

        // Turn the tank off.
        //gameObject.SetActive(false);
        //StartCoroutine(DelayDeath());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
        TakeDamage(20f);
    }


    private void OnDisable()
    {
        // When the tank is turned off, set it to kinematic so it stops moving.
        rb.isKinematic = true;
    }


    private void Start()
    {
        // The axes names are based on player number.
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";

        // Store the original pitch of the audio source.
        m_OriginalPitch = m_MovementAudio.pitch;

        //TankService.Instance.GetTank();
    }


    private void Update()
    {
        // Store the value of both input axes.
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

        EngineAudio();

        if (SC_MobileControls.instance.GetMobileButtonDown("FireButton") || Input.GetKeyDown(KeyCode.LeftControl))
        {
            //Mobile button has been pressed one time, equivalent to if(Input.GetKeyDown(KeyCode...))
            GameObject shell = Instantiate(shells, fireTransform.position, transform.rotation);

            Rigidbody shellBody = shell.GetComponent<Rigidbody>();

            shellBody.AddForce(transform.forward * fireForce);
        }


        if (SC_MobileControls.instance.GetMobileButton("FireButton"))
        {
            //Mobile button is being held pressed, equivalent to if(Input.GetKey(KeyCode...))
        }
    }


    private void EngineAudio()
    {
        // If there is no input (the tank is stationary)...
        if (Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f)
        {
            // ... and if the audio source is currently playing the driving clip...
            if (m_MovementAudio.clip == m_EngineDriving)
            {
                // ... change the clip to idling and play it.
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
        else
        {
            // Otherwise if the tank is moving and if the idling clip is currently playing...
            if (m_MovementAudio.clip == m_EngineIdling)
            {
                // ... change the clip to driving and play.
                m_MovementAudio.clip = m_EngineDriving;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
    }


    private void FixedUpdate()
    {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();

        //Get normalized direction of a on-screen Joystick
        //Could be compared to: new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) or new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))
        Vector2 inputAxis = SC_MobileControls.instance.GetJoystick("JoystickLeft");

    }


    private void Move()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        rb.MovePosition(rb.position + movement);
    }


    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}