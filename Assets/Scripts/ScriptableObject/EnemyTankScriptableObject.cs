using BattleTank.PlayerTank;
using UnityEditor;
using UnityEngine;

namespace BattleTank.EnemyTank
{
    [CreateAssetMenu (fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/CreateNewEnemyTankScriptableObject")]
    public class EnemyTankScriptableObject : ScriptableObject
    {
        public EnemyTankType EnemyTankType;
        public string EnemyTankName;
        public int EnemyMovementSpeed;
        public float EnemyRotationSpeed;
        public int EnemyHealth;
        public EnemyTankView EnemyTankView;
    }
}