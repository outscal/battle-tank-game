using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController enemyTankController;
    public GameObject explosionPrefab;

    private float startingHealth;
    private Color fullHealthColor = Color.green;
    private Color zeroHealthColor = Color.red;
    internal AudioSource explosionAudio;
    internal ParticleSystem explosionParticles;

    public Slider healthSlider;
    public Image fillImage;

    public void SetEnemyTankController(EnemyTankController _enemyTankController)
    {
        enemyTankController = _enemyTankController;
    }

    void Start()
    {
        Intitalization();
        SetHealthUI();
    }

    private void Intitalization()
    {
        startingHealth = enemyTankController.GetEnemyTankModel().tankHealth;
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    public void SetHealthUI()
    {
        healthSlider.value = enemyTankController.GetEnemyTankModel().tankHealth;
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, enemyTankController.GetEnemyTankModel().tankHealth / startingHealth);
    }
}

