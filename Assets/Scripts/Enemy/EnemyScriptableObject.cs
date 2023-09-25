using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/NewEnemyScriptableObjects")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyTypes type;
    public float speed;
    public float turnSpeed;
    public float health;
    public float damage;
    public EnemyView enemyView;
}
