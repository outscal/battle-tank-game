
using UnityEngine;

public class EnemyTankModel
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }

    public float health;

    public TankTypes type { get; private set; }

    private EnemyTankController tankController;

    public EnemyTankModel(TankScriptableObject tankScriptableObject)
    {
        movementSpeed = tankScriptableObject.movementSpeed;
        rotationSpeed = tankScriptableObject.rotationSpeed;
        health = tankScriptableObject.health;
        type = tankScriptableObject.tankType;
    }
    public void SetEnemyTankController(EnemyTankController tankController)
    {
        this.tankController = tankController;
    }

}
