using UnityEngine;

public class EnemyController
{
    private EnemyModel EnemyModel { get; }
    private EnemyView EnemyView { get; }

    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-10,10);
        float randomZ = Random.Range(-10,10);
        return new Vector3(randomX, 0f, randomZ);
    }
    public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
    {
        EnemyModel = enemyModel;
        EnemyView = GameObject.Instantiate<EnemyView>(enemyView, GetRandomSpawnPosition(), Quaternion.identity);
        EnemyView.SetEnemyController(this);
    }
    public EnemyModel GetEnemyModel()
    {
        return EnemyModel;
    }
}
