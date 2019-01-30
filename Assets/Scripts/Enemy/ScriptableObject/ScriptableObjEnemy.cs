using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyScriptableObj", menuName = "ScriptableObj/EnemyObj", order = 1)]
    public class ScriptableObjEnemy : ScriptableObject
    {
        public float moveSpeed;
        public float health;
        public GameObject enemyPrefab;
    }
}