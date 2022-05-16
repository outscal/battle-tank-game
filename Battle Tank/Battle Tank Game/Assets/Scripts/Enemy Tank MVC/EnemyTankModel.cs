using UnityEngine;

public class EnemyTankModel 
{
    public EnemyTankType enemyTankType;
    public float tankHealth;
    public float startingHealth;
    public float tankDamage;
    public float tankSpeed;
    public float tankTurnSpeed;
    public Color fullHealthColor;
    public Color zeroHealthColor;

    public EnemyTankModel(EnemyTankScriptableObjects enemySO)
    {
        enemyTankType = enemySO.tankType;
        tankHealth = enemySO.tankHealth;
        startingHealth = enemySO.tankHealth;
        tankDamage = enemySO.tankDamage;

        tankSpeed = enemySO.tankSpeed;
        tankTurnSpeed = enemySO.tankTurnSpeed;

        fullHealthColor = Color.green;
        zeroHealthColor = Color.red;
    }   
   
}
