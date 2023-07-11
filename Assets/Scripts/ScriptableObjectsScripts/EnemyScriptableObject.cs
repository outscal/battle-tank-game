using BattleTank.Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/NewEnemyTank")]
public class EnemyScriptableObject : ScriptableObject
{
    public int health;
    public int speed;
    public int strength;
    public int bpm;

    public float rotationSpeed;
    public float visibilityRange;
    public float detectionRange;

    public BulletType bulletType;
    public EnemyView enemyView;
}
