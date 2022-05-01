using UnityEngine;

public class EnemyTankModel 
{
    private EnemyTankController enemyTankController;

    public float tankHealth;    

    public EnemyTankModel(float _tankHealth)
    {
        tankHealth = _tankHealth;
    }

    public void SetEnemyTankController(EnemyTankController _enemyTankController)
    {
        enemyTankController = _enemyTankController;
    }
   
}
