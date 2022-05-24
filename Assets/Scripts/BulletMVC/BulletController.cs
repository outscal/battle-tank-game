using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    public BulletModel BulletModel { get; }
    public BulletView BulletView { get; }
    //public ExplosionParticesForBullet ExplosionParticesForBullet;

    // This Constructor Spawns a bullet and Fire it just after it is Spawned.
    public BulletController(BulletModel bulletModel, BulletView bulletView, Transform BulletSpawner)
    {
        BulletModel = bulletModel;
        BulletView = GameObject.Instantiate<BulletView>(bulletView, BulletSpawner.position, BulletSpawner.rotation);
        BulletView.Initialize(this);
        BulletView.GetComponent<Rigidbody>().AddForce(BulletView.transform.forward * BulletModel.Speed, ForceMode.VelocityChange);
    }

    public void InflictDamage(GameObject collider)
    {
        IDamagable damage = collider.GetComponent<IDamagable>();
        if (damage != null)
        {
            damage.TakeDamage(BulletModel.Damage);
        }
    }
 
}