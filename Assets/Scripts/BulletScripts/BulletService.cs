using UnityEngine;
public enum BulletType
{
    Sniper, Assault, Pistol
}
public class BulletService : GenericSingleton<BulletService>
{
    [SerializeField] BulletScriptableObjectList bulletList;
    [SerializeField] ParticleSystem bulletExplosion;
    public void SpawnBullet(BulletType bulletType, Transform _transform)
    {
        BulletController bulletController = new BulletController(bulletList.bullets[(int)bulletType], _transform);
    }
    public void BulletExplosion(Vector3 position, BulletView bulletView)
    {
        ParticleSystem explosion = GameObject.Instantiate<ParticleSystem>(bulletExplosion, position, Quaternion.identity);
        explosion.Play();
        Destroy(bulletView.gameObject);
    }
}
