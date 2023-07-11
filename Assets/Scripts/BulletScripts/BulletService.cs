using UnityEngine;
using BattleTank.Generics;
using BattleTank.ScriptableObjects;

public enum BulletType
{
    Sniper, Assault, Pistol
}

namespace BattleTank.Bullet
{
    public class BulletService : GenericSingleton<BulletService>
    {
        [SerializeField] private BulletScriptableObjectList bulletList;
        [SerializeField] private ParticleSystem bulletExplosion;

        public void SpawnBullet(BulletType bulletType, Transform _transform, TankType tankType)
        {
            BulletController bulletController = new BulletController(bulletList.bullets[(int)bulletType], _transform, tankType);
        }

        public void BulletExplosion(Vector3 position, BulletView bulletView)
        {
            ParticleSystem explosion = GameObject.Instantiate<ParticleSystem>(bulletExplosion, position, Quaternion.identity);
            explosion.Play();
            Destroy(bulletView.gameObject);
        }
    }
}
