using UnityEngine;

public class EnemyTankModel 
{
    private EnemyTankController enemyTankController;

    public float tankHealth;    
    public float tankDamage;

    public EnemyTankModel(float _tankHealth, float _tankDamage)
    {
        tankHealth = _tankHealth;
        tankDamage = _tankDamage;
    }

    public void SetEnemyTankController(EnemyTankController _enemyTankController)
    {
        enemyTankController = _enemyTankController;
    }
   
}
