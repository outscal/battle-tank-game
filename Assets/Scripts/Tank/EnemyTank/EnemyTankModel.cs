
using UnityEngine;

public class EnemyTankModel
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }

    public float health;

    public EnemyTankType type;


    public EnemyTankModel(EnemyTankScriptableObject tankScriptableObject)
    {
        movementSpeed = tankScriptableObject.MovementSpeed;
        rotationSpeed = tankScriptableObject.RotationSpeed;
        health = tankScriptableObject.Health;
        type = tankScriptableObject.TankType;
    }

}
