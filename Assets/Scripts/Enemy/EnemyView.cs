using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;
using Tank;

namespace Enemy
{
    [RequireComponent(typeof(AudioSource), typeof(Rigidbody), typeof(TankHealth))]
    public class EnemyView : MonoBehaviour
    {
        public Transform m_FireTransform;
        public AudioSource m_MovementAudio;
        public AudioClip m_EngineIdling;
        public AudioClip m_EngineDriving;
        public ParticleSystem[] m_particleSystems;

        private Rigidbody m_Rigidbody;
        EnemyController enemyController;

        internal void Initialize(EnemyController controller)
        {
            enemyController = controller;
            InitAllVariables();
        }


        private void InitAllVariables()
        {
            transform.SetParent(enemyController.C_EnemyParent);
            m_Rigidbody = GetComponent<Rigidbody>();
            GetComponent<TankHealth>().Initialize(enemyController);
            //Debug.Log("Health " + tankController.GetModel().Health, this);
            m_Rigidbody.isKinematic = false;

            for (int i = 0; i < m_particleSystems.Length; ++i)
            {
                m_particleSystems[i].Play();
            }
        }

        private void Update()
        {
            //enemyController.PlayEngineAudio(m_MovementInputValue, m_TurnInputValue, m_MovementAudio,
            //                           m_EngineDriving, m_EngineIdling, m_OriginalPitch);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<TankView>())
            {
                TankHealth targetHealth = collision.gameObject.GetComponent<TankHealth>();
                targetHealth.TakeDamage(100);
            }
        }

    }
}
