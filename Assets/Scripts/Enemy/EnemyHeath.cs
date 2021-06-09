using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    public EnemySribtableObject enemyData;
    public HealthBar healthBar;
    private int maxHealth;
    private int currentHealth;

    private void Start()
    {
        maxHealth = enemyData.enemyHealth;
        maxHealth = currentHealth;
    }

    private void Update()
    {
        TakeDamage(20);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
