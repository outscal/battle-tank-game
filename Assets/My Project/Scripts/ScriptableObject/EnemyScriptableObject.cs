using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/NewEnemyTank")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public int health;
        public int speed;
        public int strength;

        public EnemyView enemyView;
    }
}