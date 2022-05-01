using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private GameObject[] tankBody;   
    
    public Rigidbody rb;
    public GameObject explosionPrefab;
    public Slider healthSlider;
    public Image fillImage;    
    //heath variables
    [HideInInspector] private float startingHealth;    
    private Color fullHealthColor = Color.green;
    private Color zeroHealthColor = Color.red;
    
    internal AudioSource explosionAudio;
    internal ParticleSystem explosionParticles;

    //shooting variable
    public Rigidbody shell;
    public Transform fireTransform;
    public Slider aimSlider;
    public AudioSource shootingAudio;
    public AudioClip chargingClip;
    public AudioClip fireClip;


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

    private void Intitalization()
    {
        tankBody = GameObject.FindGameObjectsWithTag("TankBody");        
        startingHealth = tankController.GetTankModel().tankHealth;
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);             
    }  

    public void SetHealthUI()
    {
        healthSlider.value = tankController.GetTankModel().tankHealth;        
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, tankController.GetTankModel().tankHealth / startingHealth);
    }    

    private void CameraToFollowTank()
    {        
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.SetParent(transform);
        camera.transform.position = new Vector3(0f, 4f, -5f);
    }

    private void ChangeTankColor()
    {
        for(int i = 0; i < tankBody.Length; i++)
        {
            tankBody[i].GetComponent<Renderer>().material.color = tankController.GetTankModel().tankColor;
        }
    }
    
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
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
}
