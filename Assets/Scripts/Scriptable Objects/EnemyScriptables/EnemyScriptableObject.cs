using BulletServices;
using EnemyTankServices;
using UnityEngine;

namespace EnemyScriptables
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy/EnemyScriptableObject")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public EnemyType enemyType;
        public Color tankColor;
        public BulletType bulletType;
        public int health;
        public float movementSpeed;
        public float rotationSpeed;
        public float turretRotationRate;
        public float walkPointRange;
        public float patrollingRange;
        public float patrolTime;
        public float fireRate;
        public float attackRange;
        public float minLaunchForce;
        public float maxLaunchForce;

    }
}