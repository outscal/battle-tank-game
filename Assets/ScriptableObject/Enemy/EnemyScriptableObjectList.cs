using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySO
{
    [CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObject/Enemy/CreateEnemyList")]
    public class EnemyScriptableObjectList : ScriptableObject
    {
        public EnemyScriptableObject[] enemies;
    }
}
