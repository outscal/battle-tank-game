using UnityEngine;

public class BulletService : GenericSingleton<BulletService>
{
    [SerializeField] BulletView bulletView;
    void Start()
    {
        SpawnBullet(new Vector3(0, 1.55f, 1));
    }
    void SpawnBullet(Vector3 position)
    {
        BulletController bulletController = new BulletController(bulletView, 10, 15, position);
    }
}
