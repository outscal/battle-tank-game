using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyTankListScriptableObject", menuName = "ScriptableObject/EnemyTank/New EnemyTankList ScriptableObject")]
public class EnemyTankListSO : ScriptableObject
{
    public EnemyTankSO[] enemyTanks;
}