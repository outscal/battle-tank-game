using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankList", menuName = "ScriptableObjects/NewEnemyTankList")]
public class EnemyTankList : ScriptableObject
{
    public EnemyTankScriptableObjects[] enemyTanks;
}
