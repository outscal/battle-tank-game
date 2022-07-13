using BulletServices;
using EnemyTankServices;
using UnityEngine;

namespace EnemySO
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy/EnemyScriptableObject")]
    public class EnemyScriptableObject : ScriptableObject
    {
        [Header("Enemy Type")]
        public EnemyType enemyType;

        [Header("Enemy Prefab")]
        public Color tankColor;

        [Header("Health Parameters")]
        public int health;

        [Header("Movement Parameters")]
        public float movementSpeed;
        public float rotationSpeed;
        public float turretRotationRate;
        public float walkPointRange;
        public float patrollingRange;
        public float patrolTime;

        [Header("Attack Parameters")]
        public float fireRate;
        public float attackRange;
        public float minLaunchForce;
        public float maxLaunchForce;
        public BulletType bulletType;
    }
}