using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    public EnemyTankController enemyTankController;
    [HideInInspector]public Transform playerTransform;
    public GameObject explosionPrefab; 
    
    internal AudioSource explosionAudio;
    internal ParticleSystem explosionParticles;

    public Slider healthSlider;
    public Image fillImage;

    //public StateMachine stateMachine;
    public NavMeshAgent agent; 
    



    void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    void Start()
    {
        Intitalization();
        enemyTankController.SetHealthUI();
    }
    
    private void Intitalization()
    {   
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();         
    }
  
    public void Death()
    {
        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);

        explosionParticles.Play();
        explosionAudio.Play();

        Destroy(gameObject);
    }
}

