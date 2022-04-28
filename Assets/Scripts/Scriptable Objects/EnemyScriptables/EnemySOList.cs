using UnityEngine;

namespace EnemyScriptables
{
    [CreateAssetMenu(fileName = "EnemySOList", menuName = "ScriptableObject/Enemy/EnemyScriptableObjectList")]
    public class EnemySOList : ScriptableObject
    {
        public EnemyScriptableObject[] enemies;
    }
}