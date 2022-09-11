using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{

    private TankController tankController;
    
    
    private float movementInput;
   

    
    public Rigidbody rb;

   

     // TANK HEALTH
     float lerpSpeed;

    private float rotationInput;

    private float currentHealth;
     public Image healthFill;
     public float Startinghealth = 100f;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;

     public AudioSource m_ExplosionAudio;               // The audio source to play when the tank explodes.
    public ParticleSystem m_ExplosionParticles;        // The particle system the will play when the tank is destroyed.

        public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
    public Slider m_AimSlider;                  // A child of the tank that displays the current launch force.
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
    public AudioClip m_ChargingClip;            // Audio that plays when each shot is charging up.
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.


    
     
    // Tank Death
      private bool tankDead;
     public GameObject m_ExplosionPrefab;
    
    
   
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f,3f,-5f);
        
    }


     public void OnEnable()
    {
        currentHealth = Startinghealth;
         tankDead = false;
        SetHealthUI();
       
     
    }

   
    void Update()
    {
        // Tank Movement
        GetInput();
        if(movementInput != 0)
        {
           
           tankController.Move(movementInput);
           
        }
          
        if(rotationInput != 0)
        {
           tankController.Rotate(rotationInput);
           
        } 
       
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        SetHealthUI();

        if (currentHealth <= 0f && !tankDead)
        {
            OnDeath();
        }
    }


   // User Input
    private void GetInput()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput =  Input.GetAxis("Horizontal");
    }

    
   // Health 
    void SetHealthUI()
    {
        
        healthFill.fillAmount = Mathf.Lerp(healthFill.fillAmount,currentHealth / Startinghealth, lerpSpeed);
        Color Healthcolor = Color.Lerp(m_ZeroHealthColor,m_FullHealthColor,(currentHealth/Startinghealth));
        healthFill.color = Healthcolor;
    }

    private void OnDeath()
    {

        tankDead = true;
        m_ExplosionParticles.gameObject.SetActive(true);
         m_ExplosionParticles.Play();
         m_ExplosionAudio.Play();
        gameObject.SetActive(false);
        Destroy(gameObject);

    }


    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;

    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    
}
