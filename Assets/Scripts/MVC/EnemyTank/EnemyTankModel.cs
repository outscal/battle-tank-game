using UnityEngine;
public class EnemyTankModel
{
    //enemyTank properties
    public EnemyTankTypes EnemyTankType;
    public string EnemyTankName;
    public float MovementSpeed { get; }
    public float RotationSpeed { get; }
    public float Health { get; }
    public Color EnemyTankColor { get; }
    public Joystick Joystick { get; }

    EnemyTankController _enemyTankController;

    //constructor
    public EnemyTankModel(EnemyTankSO enemyTankScriptableObject)
    {
        EnemyTankType = enemyTankScriptableObject.EnemyTankType;
        EnemyTankName = enemyTankScriptableObject.EnemyTankName;
        MovementSpeed = enemyTankScriptableObject.MovementSpeed;
        RotationSpeed = enemyTankScriptableObject.RotationSpeed;
        Health = enemyTankScriptableObject.Health;
        EnemyTankColor = enemyTankScriptableObject.EnemyTankColor;
    }


    public void SetController(EnemyTankController enemyTankController)
    {
        _enemyTankController = enemyTankController;
    }

}