using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{

    [CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObjects/NewEnemyObjectList")]
    public class EnemyScriptableObjectList : ScriptableObject
    {
        public EnemyScriptableObject[] enemies;
    }
}
