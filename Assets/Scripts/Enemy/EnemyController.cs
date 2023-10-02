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

    public bool TakeDamage(float damage)
    {
        if (EnemyModel.Health <= 0) return false;

        EnemyModel.Health = (int)Mathf.Clamp(EnemyModel.Health - damage, 0, EnemyModel.MaxHealth);

        if (EnemyModel.Health == 0)
            DestroyEnemy();

        return true;
    }

    public bool GiveDamage(IDamagable damagable)
    {
        return damagable.TakeDamage(EnemyModel.Damage);
    }

    public void DestroyEnemy()
    {
        GameObject explosion = GameObject.Instantiate(EnemyModel.Explosion, EnemyView.transform.position, Quaternion.identity);
        GameObject.Destroy(explosion, 1.5f);
        AssetManager.Instance.RemoveEnemyView(EnemyView);
        GameObject.Destroy(EnemyView.gameObject);
    }
}
