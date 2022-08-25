using UnityEngine;
using EnemyTankServices;

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
        public float patrolPointRange;
        public float patrollingRange;
        public float patrolTime;
    }
}
