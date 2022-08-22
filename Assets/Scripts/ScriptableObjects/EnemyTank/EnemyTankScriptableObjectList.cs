using UnityEngine;

namespace EnemyScriptableObjects

{
    [CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObject/Enemy/EnemyScriptableObjectList")]
    public class EnemyTankScriptableObjectList : ScriptableObject
    {
        public EnemyTankScriptableObject[] enemyTankScriptableObject;
    }
}
