using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/NewEnemyScriptableObjects")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyTypes type;
    public float speed;
    public float turnSpeed;
    public float health;
    public float damage;
    public float fireRate;
    public float detectionRadius;
    public float attackRange;
    public float fieldOfView;
    public LayerMask shellLayer;
    public EnemyView enemyView;
    public GameObject enemyExplosion;
}
