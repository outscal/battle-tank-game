using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/NewEnemyTankScriptableObject")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public string enemyTankName;
    public float speed;
    public int health;
    public float rotationSpeed;
}
