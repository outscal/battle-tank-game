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
            if (enemyTankScriptableObject == null)
                continue;

            new EnemyTankController(enemyTankScriptableObject);
        }

    }

    EnemyTankScriptableObject Spawn()
    {
        int index = GetRadomIndexBasedOnSpawnChance();

        if (index < 0)
            return null;

        return enemyTankScriptableObjectList.enemyTankList[index];
    }

    int GetRadomIndexBasedOnSpawnChance()
    {
        int min = int.MaxValue, max = int.MinValue;
        foreach (EnemyTankScriptableObject enemyTankScriptableObject in enemyTankScriptableObjectList.enemyTankList)
        {
            min = Mathf.Min(min, enemyTankScriptableObject.SpawnChance);
            max = Mathf.Max(max, enemyTankScriptableObject.SpawnChance);
        }

        float random = UnityEngine.Random.Range(max, min - 1);
        float diff = int.MaxValue;
        int index = -1;
        for (int i = 0; i < enemyTankScriptableObjectList.enemyTankList.Length; i++)
        {
            EnemyTankScriptableObject enemyTankScriptableObject = enemyTankScriptableObjectList.enemyTankList[i];
            float _diff = Mathf.Abs(random - enemyTankScriptableObject.SpawnChance);
            if (_diff < diff)
            {
                diff = _diff;
                index = i;
            }
        }

        return index;
    }
}