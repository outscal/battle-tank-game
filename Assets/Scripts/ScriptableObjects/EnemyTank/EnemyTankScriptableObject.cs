using UnityEngine;
using EnemyTankServices;
using BulletServices;

namespace  EnemyScriptableObjects {
    [CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/Enemy/EnemyTankScriptableObject")]
    public class EnemyTankScriptableObject : ScriptableObject
    {
        [Header("Enemy Tank Type")]
        public EnemyType enemyType;

        [Header("Enemy Tank Prefab Colour")]
        public Color color;

        [Header("Enemy Tank Health")]
        public int health;

        [Header("Movement Parameters")]
        public float speed;
        public float rotationSpeed;
        public float turretRotationSpeed;
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
