using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyListHolder", menuName = "ScriptableObj/EnemyList", order = 0)]
    public class ScriptableObjEnemyList : ScriptableObject
    {
        public List<ScriptableObjEnemy> enemyList;
    }
}