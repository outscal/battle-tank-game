using UnityEngine;

namespace BattleTank.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObjects/NewEnemyObjectList")]
    public class EnemyScriptableObjectList : ScriptableObject
    {
        public EnemyScriptableObject[] enemies;
    }
}
