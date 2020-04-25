using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;
using Tank;

namespace Enemy
{
    [RequireComponent(typeof(AudioSource), typeof(Rigidbody), typeof(EnemyHealth))]
    public class EnemyView : MonoBehaviour
    {
        public Transform FireTransform;
        public AudioSource MovementAudio;
        public AudioClip EngineIdling;
        public AudioClip EngineDriving;
        public ParticleSystem[] particleSystems;

        private Rigidbody enemyBody;
        EnemyController enemyController;

        internal void Initialize(EnemyController controller)
        {
            enemyController = controller;
            InitAllVariables();
        }


        private void InitAllVariables()
        {
            transform.SetParent(enemyController.EnemyParent);
            enemyBody = GetComponent<Rigidbody>();
            GetComponent<EnemyHealth>().Initialize(enemyController);

            enemyBody.isKinematic = false;

            for (int i = 0; i < particleSystems.Length; ++i)
            {
                particleSystems[i].Play();
            }
        }

        private void Update()
        {
            //enemyController.PlayEngineAudio(m_MovementInputValue, m_TurnInputValue, m_MovementAudio,
            //                           m_EngineDriving, m_EngineIdling, m_OriginalPitch);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<TankHealth>() != null)
            {
                TankHealth destructable = collision.gameObject.GetComponent<TankHealth>();
                destructable.TakeDamage(100);
            }
        }


        public void KillView()
        {
            Destroy(gameObject);
        }

    }
}
