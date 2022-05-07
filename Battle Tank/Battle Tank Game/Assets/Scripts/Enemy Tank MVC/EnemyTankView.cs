using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController enemyTankController;
    public GameObject explosionPrefab;
    private Transform currentPosition;

    private float startingHealth;
    private Color fullHealthColor = Color.green;
    private Color zeroHealthColor = Color.red;
    internal AudioSource explosionAudio;
    internal ParticleSystem explosionParticles;

    public Slider healthSlider;
    public Image fillImage;

    //public StateMachine stateMachine;

    public void SetEnemyTankController(EnemyTankController _enemyTankController)
    {
        enemyTankController = _enemyTankController;
    }

    void Start()
    {
        Intitalization();
        SetHealthUI();
        RandomPositionForTank();        
    }

    private void Intitalization()
    {   
        currentPosition = GetComponent<Transform>();        
        startingHealth = enemyTankController.GetEnemyTankModel().tankHealth;
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);        
    }

    public EnemyTankController GetEnemyTankController()
    {
        return enemyTankController;
    }

    public void SetHealthUI()
    {
        healthSlider.value = enemyTankController.GetEnemyTankModel().tankHealth;
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, enemyTankController.GetEnemyTankModel().tankHealth / startingHealth);
    }

    private void RandomPositionForTank()
    {
        //function for randomly spawn enemy tanks to different locations
        //float randomX = UnityEngine.Random.Range();
    }
}

