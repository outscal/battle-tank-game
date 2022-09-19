using UnityEngine;
using AllServices;

namespace BulletServices
{
    // Handles all behaviour of bullet.
    public class BulletController
    {
        public BulletModel bulletModel { get; }
        public BulletView bulletView { get; }

        // This Constructor Spawns a bullet and Fire it just after it is Spawned.
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform bulletSpawner, float launchForce)
        {
            this.bulletModel = bulletModel;

            bulletView = GameObject.Instantiate<BulletView>(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            bulletView.BulletInitialize(this);

            bulletView.GetComponent<Rigidbody>().velocity = bulletSpawner.forward * launchForce;
        }

        // Applies damage to the object collided with bullet.
        public void OnCollisionEnter(Collider other)
        {
            IDamagable damagable = other.GetComponent<IDamagable>();

            if (damagable != null)
            {
                ApplyDamage(damagable, other);
            }

            bulletView.DestroyBullet();
        }

        // Applies damage only if the collided object has rigidbody component.
        private void ApplyDamage(IDamagable damagable, Collider other)
        {
            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();

            if (targetRigidbody)
            {
                damagable.TakeDamage(bulletModel.bulletDamage);
            }
        }
    }
}
