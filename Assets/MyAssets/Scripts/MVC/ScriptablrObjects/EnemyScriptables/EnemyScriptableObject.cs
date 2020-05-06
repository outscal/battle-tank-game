using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.View;
using ScriptableObj;

namespace enemyScrtiptables
{
    [CreateAssetMenu(fileName ="EnemyScriptableObject", menuName ="ScriptableObjects/NewEnemyScriptableObject")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public EnemyType enemyType;
        public float speed;
        public float turn;
        public float health;
        public BulletScriptableObject BulletType;
        public EnemyView enemyView;
    }

    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankListScriptableObject")]
    public class EnemyScriptableObjectList : ScriptableObject
    {
        public EnemyScriptableObject[] enemyTanks;
    }
}