
using UnityEngine;

public class EnemyTankModel
{
    public float MovementSpeed { get; private set; }
    public float RotationSpeed { get; private set; }

    public float ChaseRadius;

    public float FightRadius;

    public int Health;

    public EnemyTankType Type;


    public EnemyTankModel(EnemyTankScriptableObject tankScriptableObject)
    {
        MovementSpeed = tankScriptableObject.MovementSpeed;
        RotationSpeed = tankScriptableObject.RotationSpeed;
        Health = tankScriptableObject.Health;
        Type = tankScriptableObject.TankType;
        ChaseRadius = tankScriptableObject.ChaseRadius;
        FightRadius = tankScriptableObject.FightRadius;
    }

}
