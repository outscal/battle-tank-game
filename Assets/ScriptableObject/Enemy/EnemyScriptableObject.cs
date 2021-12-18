using BulletSO;
using UnityEngine;
using EnemyServices;
using TankServices;

namespace EnemySO
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy/NewEnemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public EnemyView enemyView;
        public BoxCollider ground;
        public float health;
        public float fireRate;
        public BulletScriptableObject bulletType;
    }
}
