using UnityEngine;

namespace EnemySO
{
    [CreateAssetMenu(fileName = "EnemySOList", menuName = "ScriptableObject/Enemy/EnemyScriptableObjectList")]
    public class EnemySOList : ScriptableObject
    {
        public EnemyScriptableObject[] enemies;
    }
}