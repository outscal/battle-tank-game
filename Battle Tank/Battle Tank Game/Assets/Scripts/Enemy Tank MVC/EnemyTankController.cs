using System;
using UnityEngine;

public class EnemyTankController
{
   private EnemyTankModel enemyTankModel {get; }
   private EnemyTankView enemyTankView {get; }

   private bool isDead;

   public EnemyTankController(EnemyTankModel _enemyTankModel, EnemyTankView _enemyTankView)
   {
       this.enemyTankModel = _enemyTankModel;
       enemyTankView = GameObject.Instantiate<EnemyTankView>(_enemyTankView, new Vector3(-5,0,-5), new Quaternion(0,0,0,0));
              
       enemyTankView.enemyTankController = this;
   }

   public EnemyTankModel GetEnemyTankModel()
   {
       return enemyTankModel;
   }

    public void SetHealthUI()
    {
        enemyTankView.healthSlider.value = enemyTankModel.tankHealth;
        enemyTankView.fillImage.color = Color.Lerp(enemyTankModel.zeroHealthColor, enemyTankModel.fullHealthColor, enemyTankModel.tankHealth / enemyTankModel.startingHealth);
    }

    public void TakeDamage(float amount)
    {
        enemyTankModel.tankHealth -= amount;
        SetHealthUI();

        if(enemyTankModel.tankHealth <= 0f && !isDead)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        isDead = true;

        enemyTankView.Death();        
    }
}
