using BulletSO;
using UnityEngine;
using EnemyServices;

namespace EnemySO
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy/NewEnemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public EnemyType enemyType;
        public float health;
        public float moveSpeed;
        public float rotateSpeed;
        public BulletScriptableObject bulletType;
    }
}
