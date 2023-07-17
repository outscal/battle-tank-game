using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Sniper, Assault, Pistol
}
public class BulletS : GenericSingleTon<BulletS>
{
    [SerializeField] BulletSoList bulletList;
    [SerializeField] ParticleSystem bulletExplosion;
    public void SpawnBullet(BulletType bulletType, Transform _transform)
    {
        BulletC bulletController = new BulletC(bulletList.bullets[(int)bulletType], _transform);
    }
    public void BulletExplosion(Vector3 position, BulletVi bulletView)
    {
        ParticleSystem explosion = GameObject.Instantiate<ParticleSystem>(bulletExplosion, position, Quaternion.identity);
        explosion.Play();
        Destroy(bulletView.gameObject);
    }
}
