using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private GameObject[] tankBody;   
    private GameObject m_camera;
    
    public Rigidbody rb;
    public GameObject explosionPrefab;
    
    //heath variables
    public Slider healthSlider;
    public Image fillImage;    
    [HideInInspector] private float startingHealth;    
    private Color fullHealthColor = Color.green;
    private Color zeroHealthColor = Color.red;
    private float maxHealthAtStart;
    internal AudioSource explosionAudio;
    internal ParticleSystem explosionParticles;

    //shooting variable
    public Rigidbody shell;
    public Transform fireTransform;
    public Slider aimSlider;
    public AudioSource shootingAudio;
    public AudioClip chargingClip;
    public AudioClip fireClip;
    
    //camera variables
    // private Vector3 moveVelocity;
    // private Vector3 DesiredPosition;
    // public float DampTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Intitalization();
        SetHealthUI(); 
        CameraToFollowTank();
        ChangeTankColor();
    }

    void Update()
    {
        tankController.GetInput();
        tankController.Movement();
        tankController.GetFireInput(); 
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    private void Intitalization()
    {
        m_camera = GameObject.Find("Main Camera");
        tankBody = GameObject.FindGameObjectsWithTag("TankBody");        
        startingHealth = tankController.GetTankModel().tankHealth;
        aimSlider.maxValue = startingHealth;
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);             
    }  

    public void SetHealthUI()
    {
        healthSlider.value = tankController.GetTankModel().tankHealth;
        Debug.Log("tank health " + tankController.GetTankModel().tankHealth);
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, tankController.GetTankModel().tankHealth / startingHealth);
    }  

    public TankController GetTankController()
    {
        return tankController;
    }  

    private void CameraToFollowTank()
    {        
        m_camera.transform.SetParent(transform);
        m_camera.transform.position = new Vector3(0f, 4f, -5f);
    }

    public void BeforePlayerDeath()
    {   
        //Gameover logic 
        StartCoroutine(DeParentCameraOnPlayerDeath());
    }
    public IEnumerator OnDeath()
    {
        yield return new WaitForSecondsRealtime(1f);
        tankController.OnDeath();
    }

    public IEnumerator DeParentCameraOnPlayerDeath()
    {
        m_camera.transform.SetParent(null);
        yield return StartCoroutine(OnDeath()); 

        //m_camera.transform.position = Vector3.SmoothDamp(transform.position, DesiredPosition, ref moveVelocity, DampTime);
    }

    private void ChangeTankColor()
    {
        for(int i = 0; i < tankBody.Length; i++)
        {
            tankBody[i].GetComponent<Renderer>().material.color = tankController.GetTankModel().tankColor;
        }
    }    

   //method to get rigidbody
   public Rigidbody GetRigidBody()
   {
       return rb;
   }   

   public void CreateShellInstance(float _currentLaunchForce)
   {
       Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
       shellInstance.velocity = _currentLaunchForce * fireTransform.forward;

       shootingAudio.clip = fireClip;
       shootingAudio.Play();
   }
   
   private void OnColliderEnter(Collision other)
   {
        if(other.collider.CompareTag("Enemy"))
        {
           tankController.TakeDamage(40);
       }
   }
}
