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

        private Rigidbody bulletBody;
        private float m_MaxDamage = 100f;                   
        private float m_LaunchForce = 15f;                   
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
            m_MaxDamage = bulletController.GetModel().BulletDamange;
            bulletBody = GetComponent<Rigidbody>();
            bulletController.MoveBullet(bulletBody, m_LaunchForce);
        }



        private void Start()
        {
            Destroy(gameObject, m_MaxLifeTime);
        }


        private void OnTriggerEnter(Collider other)
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

                float damage = CalculateDamage(targetRigidbody.position);

                targetHealth.TakeDamage(damage);
            }

            m_ExplosionParticles.transform.parent = null;

            m_ExplosionParticles.Play();

            m_ExplosionAudio.Play();

            ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
            Destroy(m_ExplosionParticles.gameObject, mainModule.duration);

            Destroy(gameObject);
        }


        private float CalculateDamage(Vector3 targetPosition)
        {
            Vector3 explosionToTarget = targetPosition - transform.position;

            float explosionDistance = explosionToTarget.magnitude;

            float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

            float damage = relativeDistance * m_MaxDamage;

            damage = Mathf.Max(0f, damage);

            return damage;
        }
    }
}
