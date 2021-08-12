using UnityEditor;
using UnityEngine;

namespace Outscal.BattleTank
{
    [CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/NewEnemyTankScriptableObject")]

    public class EnemyTankScriptableObject : ScriptableObject
    {
        public EnemyTankType EnemyTankType;
        public string TankName;
        public float Speed;
        public int Health;
        public EnemyTankView EnemyTankView;
    }
}