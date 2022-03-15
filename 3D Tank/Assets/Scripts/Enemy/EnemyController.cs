using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    [SerializeField] Slider m_Slider;
    [SerializeField] Image m_FillImage;
    [SerializeField] ParticleSystem particle;

    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    private int playerAttack;
    private Color m_FullHealthColor = Color.green;
    private Color m_ZeroHealthColor = Color.red;


    public EnemyController(EnemyTankModel model, EnemyTankView tankprefab)  //Instantiating the tank prefab
    {
        Model = model; 
        tankView = GameObject.Instantiate<EnemyTankView>(tankprefab,EnemyTankService.Instance.spawnPoints[Random.Range(0,3)]);
    }

    public EnemyTankModel Model { get; }
    public EnemyTankView tankView { get; }

    public void Start()
    {
        enemyMaxHealth = EnemyTankService.Instance.GetEnemyController().Model.Health;
        playerAttack = TankService.Instance.getController().Model.Attack;
        this.enemyCurrentHealth = enemyMaxHealth;
        particle = FindObjectOfType<ParticleSystem>();
    }

    public void EnemyTakeDamage()
    {
        enemyCurrentHealth -= playerAttack;    // Reduce current health by the amount of damage done.

        SetHealthUI();                         // Change the UI elements appropriately.

        if (enemyCurrentHealth <= 0f)          // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        {   
            StartCoroutine(Death());
        }
    }
    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        m_Slider.value = enemyCurrentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, enemyCurrentHealth / enemyMaxHealth);
    }

    public IEnumerator Death()    //Method for destruction of tank prefab
    {
        EnemyTankService.Instance.noOfTanks--;
        particle.transform.parent = null;
        particle.Play();
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
