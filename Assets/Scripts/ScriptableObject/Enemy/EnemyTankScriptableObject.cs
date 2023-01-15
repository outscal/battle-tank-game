using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/Enemy Tank Scriptable Object")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public EnemyTankType eTankType;
    public float Speed;
    public float Health;
    public float Damage;
    public GameObject prefab;
}
