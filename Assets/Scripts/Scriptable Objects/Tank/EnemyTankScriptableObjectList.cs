using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObjectList", menuName = "ScriptableObjects/Tank/Enemy List")]
public class EnemyTankScriptableObjectList : ScriptableObject
{
    public EnemyTankScriptableObject[] enemyTankList;
}