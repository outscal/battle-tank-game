using UnityEngine;

namespace BattleTank.EnemyTank
{
    [CreateAssetMenu (fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/CreateNewEnemyTankScriptableObject")]
    public class EnemyTankScriptableObject : ScriptableObject
    {
        public EnemyTankType EnemyTankType;
        public string EnemyTankName;
        public float WalkPointRange;
        public int EnemyHealth;
        public float sightRange;
        public LayerMask GroundLayerMask;
        public LayerMask PlayerLayerMask;
        public EnemyTankView EnemyTankView;
    }
}