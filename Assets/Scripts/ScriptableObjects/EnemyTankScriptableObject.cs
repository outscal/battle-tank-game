using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/NewEnemyTankScriptableObject")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public TankColor TankColor;
    public EnemyType EnemyType;
    public string TankName;
    public float Speed;
    public float Health;
    public float Damage;
    public BulletScriptableObject BulletScriptableObject;
}
