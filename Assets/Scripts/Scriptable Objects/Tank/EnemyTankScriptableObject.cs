using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/Tank/Enemy")]
public class EnemyTankScriptableObject : TankScriptableObject
{
    [SerializeField]
    EnemyTankView enemyTankViewPrefab;
    public EnemyTankView EnemyTankViewPrefab { get { return enemyTankViewPrefab; } }

    [SerializeField]
    [Range(0, 100)]
    short spawnChance;
    public short SpawnChance { get { return spawnChance; } }

    protected new TankCategory tankCategory = TankCategory.Enemy;
}
