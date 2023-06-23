using UnityEngine;
public enum BulletType
{
    Sniper, Assault, Pistol
}
public class BulletService : GenericSingleton<BulletService>
{
    [SerializeField] BulletScriptableObjectList bulletList;
    public void SpawnBullet(BulletType bulletType, Transform _transform)
    {
        BulletController bulletController = new BulletController(bulletList.bullets[(int)bulletType], _transform);
    }
}
