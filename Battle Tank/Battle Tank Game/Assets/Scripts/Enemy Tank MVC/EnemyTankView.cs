using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    [HideInInspector]public EnemyTankController enemyTankController;
    public ScoreController _scoreController;
    public GameObject explosionPrefab;     
    internal AudioSource explosionAudio;
    internal ParticleSystem explosionParticles;

    public Rigidbody shell;
    public Transform fireTransform;
    public Slider healthSlider;
    public Image fillImage;
    public float timeBetweenAttacks;
    public bool alreadyAttacked;


    void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
        _scoreController = GameObject.FindObjectOfType<ScoreController>();
    }

    void Start()
    {   
        SetHealth();          
    }

    private void SetHealth()
    {
        enemyTankController.SetHealthUI();
    }

    public void SetEnemyTankController(EnemyTankController _enemyTankController)
    {
        enemyTankController = _enemyTankController;
    }      

    public void FireShell()
    {
        float _currentLaunchForce = 20f;
        Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
        shellInstance.velocity = _currentLaunchForce * fireTransform.forward;          
    }
  
    public void Death()
    {
        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);

        explosionParticles.Play();
        explosionAudio.Play();

        //_scoreController.IncreaseScore(10);
        Destroy(this.gameObject);
    }

    public IEnumerator TimeBetweenAttack()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        alreadyAttacked = false;
    }
}

