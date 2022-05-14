using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyTankListSO", menuName = "Scriptable Object/New EnemyTankList SO")]
public class EnemyTankListSO : ScriptableObject
{
    public EnemyTankSO[] enemyTanks;
}
