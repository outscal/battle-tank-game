using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank;


namespace Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        public LayerMask m_TankMask;                        
        public ParticleSystem m_ExplosionParticles;         
        public AudioSource m_ExplosionAudio;

        public Rigidbody bulletBody;
        public float m_LaunchForce = 15f;
        private float m_MaxDamage = 50f;                                    
        private float m_ExplosionForce = 1000f;              
        private float m_MaxLifeTime = 2f;                    
        private float m_ExplosionRadius = 5f;                
        private BulletConroller bulletController;


        public void Initialize(BulletConroller bulletController)
        {
            this.bulletController = bulletController;
            InitAllVariables();
        }


        private void InitAllVariables()
        {
            bulletBody = GetComponent<Rigidbody>();
            transform.SetParent(bulletController.BulletParent);
        }


        private void Start()
        {
            Destroy(gameObject, m_MaxLifeTime);
        }


        private void OnTriggerEnter(Collider other)
        {
            BulletHitProcess();
        }


        private void BulletHitProcess()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

                if (!targetRigidbody)
                    continue;

                targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

                TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

                if (!targetHealth)
                    continue;

                float damage = bulletController.CalculateDamage(targetRigidbody.position,
                                     transform.position, m_ExplosionRadius, m_MaxDamage);

                damage += bulletController.GetModel().TankDamageBooster;
                targetHealth.TakeDamage(damage);
            }

            m_ExplosionParticles.transform.SetParent(bulletController.BulletParent);

            m_ExplosionParticles.Play();

            m_ExplosionAudio.Play();

            ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
            Destroy(m_ExplosionParticles.gameObject, mainModule.duration);

            Destroy(gameObject);
        }

    }
}
