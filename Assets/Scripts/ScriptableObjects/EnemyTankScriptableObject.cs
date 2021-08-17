using UnityEditor;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// enemy tank scriptable object
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/NewEnemyTankScriptableObject")]

    public class EnemyTankScriptableObject : ScriptableObject
    {
        public EnemyTankType EnemyTankType;
        public string TankName;
        public float Speed;
        public int Health;
        public EnemyTankView EnemyTankView;

        public float enemyHealth;
        public BoxCollider groundArea;

        [Header("Enemy Shooting Variables")]
        public float fireRate;
        public BulletScriptableObject bulletType;
    }

    [CreateAssetMenu(fileName ="EnemyTankScriptableObject",menuName ="ScriptableObjects/NewEnemyTankListrScriptableObjects")]

    public class EnemyTankScriptableObjectList : ScriptableObject
    {
        public EnemyTankScriptableObjectList[] enemyList;
    }
}