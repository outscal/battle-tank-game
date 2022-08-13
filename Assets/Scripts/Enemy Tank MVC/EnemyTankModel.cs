using UnityEngine;

public class EnemyTankModel 
{
    public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
    {
        Speed = enemyTankScriptableObject.speed;
        Health = enemyTankScriptableObject.health;
        RotationSpeed = enemyTankScriptableObject.rotationSpeed;
        TankName = enemyTankScriptableObject.enemyTankName;
    }

    public float Speed { get; }
    public int Health { get; set; }
    public float RotationSpeed { get; }
    public string TankName { get; }
}
