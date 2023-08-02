using UnityEngine;

public class EnemyTankService : TankService<EnemyTankService>
{
    [SerializeField]
    EnemyTankScriptableObjectList enemyTankScriptableObjectList;

    [SerializeField]
    short spawnCount;
    public short SpawnCount { get { return spawnCount; } }

    protected override void Initialize()
    {

        for (int i = 0; i < spawnCount; i++)
        {
            EnemyTankScriptableObject enemyTankScriptableObject = Spawn();

            EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankScriptableObject);

            TankController tankController = new EnemyTankController(enemyTankModel, enemyTankScriptableObject.EnemyTankViewPrefab);
        }

    }

    EnemyTankScriptableObject Spawn()
    {
        int index = (int)UnityEngine.Random.Range(0f, enemyTankScriptableObjectList.enemyTankList.Length - 1);

        return enemyTankScriptableObjectList.enemyTankList[index];
    }
}