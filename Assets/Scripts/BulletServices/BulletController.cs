using GlobalServices;
using UnityEngine;

namespace BulletServices
{
    public class BulletController 
    {
        public BulletModel bulletModel { get; }
        public BulletView bulletView { get; }

        public BulletController(BulletModel model, BulletView bulletPrefab, Transform fireTransform, float launchForce)
        {
            bulletModel = model;
            bulletView = GameObject.Instantiate<BulletView>(bulletPrefab, fireTransform.position, fireTransform.rotation);
            bulletView.SetBulletController(this);

            bulletView.GetComponent<Rigidbody>().velocity = fireTransform.forward * launchForce;
        }

        public void OnCollisionEnter(Collider other)
        { 
            IDamagable damagable = other.GetComponent<IDamagable>();

            if(damagable != null)
            {
                ApplyDamage(damagable, other);
            }

            PlayParticleEffects();
            PlayExplosionSound();

            bulletView.DestroyBullet();
        }


        private void ApplyDamage(IDamagable damagable, Collider other)
        {
            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();

            if (targetRigidbody)
            {
                damagable.TakeDamage(bulletModel.bulletDamage);
            }
        }


        private void ApplyExplosionForce(Collider other)
        {
            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();

            if (targetRigidbody)
            {
                targetRigidbody.AddExplosionForce(bulletModel.explosionForce, bulletView.transform.position, bulletModel.explosionRadius);
            }
        }


        private void PlayParticleEffects()
        {
            ParticleSystem explosionParticles = bulletView.explosionParticles;
            explosionParticles.transform.parent = null;
            explosionParticles.Play();
            bulletView.DestroyParticleSystem(explosionParticles);
        }


        private void PlayExplosionSound()
        {
            bulletView.explosionSound.Play();
        }
    }
}
