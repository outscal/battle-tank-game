using System;
using UnityEngine;

public class EnemyTankController
{
   private EnemyTankModel enemyTankModel;
   private EnemyTankView enemyTankView;

   private bool isDead;

   public EnemyTankController(EnemyTankModel _enemyTankModel, EnemyTankView _enemyTankView)
   {
       enemyTankModel = _enemyTankModel;
       enemyTankView = GameObject.Instantiate<EnemyTankView>(_enemyTankView);;
       
       enemyTankModel.SetEnemyTankController(this);
       enemyTankView.SetEnemyTankController(this);       
   }

   public EnemyTankModel GetEnemyTankModel()
   {
       return enemyTankModel;
   }

    public void TakeDamage(float amount)
    {
        enemyTankModel.tankHealth -= amount;
        enemyTankView.SetHealthUI();

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
