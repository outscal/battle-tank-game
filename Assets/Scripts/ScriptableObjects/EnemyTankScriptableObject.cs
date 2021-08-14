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
    }

    [CreateAssetMenu(fileName ="EnemyTankScriptableObject",menuName ="ScriptableObjects/NewEnemyTankListrScriptableObjects")]

    public class EnemyScriptableObjectList : ScriptableObject
    {
        public EnemyScriptableObjectList[] enemyList;
    }
}