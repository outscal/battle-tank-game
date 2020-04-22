using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;


namespace Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        public LayerMask m_TankMask;                        
        public ParticleSystem m_ExplosionParticles;         
        public AudioSource m_ExplosionAudio;

        public Rigidbody bulletBody;
        private float m_MaxDamage = 10f;                                    
        private float m_ExplosionForce = 100f;              
        private float m_MaxLifeTime = 2f;                    
        private float m_ExplosionRadius = 5f;                
        private BulletController bulletController;


        public void Initialize(BulletController bulletController)
        {
            this.bulletController = bulletController;
            InitAllVariables();
        }


        private void InitAllVariables()
        {
            bulletBody = GetComponent<Rigidbody>();
            transform.SetParent(bulletController.C_BulletParent);
        }


        private void Start()
        {
            Destroy(gameObject, m_MaxLifeTime);
        }


        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log("OnTriggerEnter " + other, this);
            BulletHitProcess();
        }


        private void BulletHitProcess()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);
            //Debug.Log("colliders " + colliders.Length, this);
            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
                //Debug.Log("targetRigidbody " + targetRigidbody, this);
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

            m_ExplosionParticles.transform.SetParent(bulletController.C_BulletParent);

            m_ExplosionParticles.Play();

            m_ExplosionAudio.Play();

            ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
            Destroy(m_ExplosionParticles.gameObject, mainModule.duration);

            BulletService.Instance.DestroyBullet(bulletController);
        }

    }
}
