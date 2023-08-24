
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy/NewEnemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyType type;
    public int speed;
    public int health;
    public EnemyView EnemyView;
    public Transform PatrolPosition;
    public int PatrolRadius;
}
[CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObject/Enemy/EnemyList")]
public class EnemyScriptableObjectList : ScriptableObject
{
    public EnemyScriptableObject[] EnemyObjects;
}