using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyTankScriptableObject", menuName = "ScriptableObject/EnemyTank/New EnemyTank ScriptableObject")]
public class EnemyTankSO : ScriptableObject
{
    public EnemyTankTypes EnemyTankType;
    public string EnemyTankName;
    public float MovementSpeed;
    public float RotationSpeed;
    public float Health;
    public Color EnemyTankColor;
}