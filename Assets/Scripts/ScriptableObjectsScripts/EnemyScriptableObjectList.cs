using UnityEngine;
using BattleTank.Enemy;
[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/NewEnemyTank")]
public class EnemyScriptableObject : ScriptableObject
{
    public int health;
    public int speed;
    public float rotationSpeed;
    public int strength;
    public int bpm;
    public float visibilityRange;
    public float detectionRange;
    public BulletType bulletType;
    public EnemyView enemyView;
}

[CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObjects/NewEnemyObjectList")]
public class EnemyScriptableObjectList : ScriptableObject
{
    public EnemyScriptableObject[] enemies;
}
