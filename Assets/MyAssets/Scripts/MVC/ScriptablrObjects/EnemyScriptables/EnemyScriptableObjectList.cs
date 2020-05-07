using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.View;

namespace enemyScrtiptables
{
    [CreateAssetMenu(fileName = "EnemyTankScriptableObjectList", menuName = "ScriptableObjects/NewEnemyListScriptableObject")]
    public class EnemyScriptableObjectList : ScriptableObject
    {
        public EnemyScriptableObject[] enemyTanks;
    }
}