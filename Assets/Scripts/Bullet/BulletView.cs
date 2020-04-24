using UnityEngine;
using Generic;
using System.Collections;
using Singalton;

namespace Bullet
{
    [RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
    public class BulletView : MonoBehaviour
    {
        public LayerMask TankMask;                        
        public Rigidbody bulletBody;

        private BulletController bulletController;


        public void Initialize(BulletController bulletController)
        {
            this.bulletController = bulletController;
            InitAllVariables();
        }


        private void InitAllVariables()
        {
            bulletBody = GetComponent<Rigidbody>();
            transform.SetParent(bulletController.BulletParent);
            SoundManager.Instance.PlaySoundClip(ClipName.ShotFiring);
            StartCoroutine(AutoDestroy());
        }


        IEnumerator AutoDestroy()
        {
            yield return new WaitForSeconds(bulletController.GetModel().MaxLifeTime);
            bulletController.DestroyBulletChain();
        }


        private void OnTriggerEnter(Collider other)
        {
            BulletHitProcess();
        }


        private void BulletHitProcess()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 
                            bulletController.GetModel().ExplosionRadius, TankMask);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

                if (!targetRigidbody)
                    continue;

                targetRigidbody.AddExplosionForce(bulletController.GetModel().ExplosionForce, 
                            transform.position, bulletController.GetModel().ExplosionRadius);

                TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

                if (!targetHealth)
                    continue;

                float damage = bulletController.CalculateDamage(targetRigidbody.position, transform.position);

                damage += bulletController.GetModel().TankDamageBooster;
                targetHealth.TakeDamage(damage);
            }

            //ExplosionParticles.transform.SetParent(bulletController.BulletParent);

            //ExplosionParticles.Play();
            VFXManager.Instance.PlayVFXClip(VFXName.BulletExplosion, 
                    transform.position, bulletController.BulletParent);

            SoundManager.Instance.PlaySoundClip(ClipName.BulletExplosion);

            //ParticleSystem.MainModule mainModule = ExplosionParticles.main;
            //Destroy(ExplosionParticles.gameObject, mainModule.duration);

            bulletController.DestroyBulletChain();
        }


        public void KillView()
        {
            Destroy(gameObject);
        }

    }
}
