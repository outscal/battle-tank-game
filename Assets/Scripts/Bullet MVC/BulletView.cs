using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is attached to the Bullet Game Object in the game.
/// </summary>

namespace BulletServices
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;

        public ParticleSystem explosionParticles;
        public AudioSource explosionSound;

        // To set bullet controller reference in bullet view.
        public void BulletInitialize(BulletController controller)
        {
            bulletController = controller;
        }

        private void OnTriggerEnter(Collider other)
        {
            bulletController.OnCollisionEnter(other);
        }

        public void DestroyBullet()
        {
            Destroy(gameObject);
        }

        public void DestroyParticleSystem(ParticleSystem particles)
        {
            Destroy(particles.gameObject, particles.main.duration);
        }
    }
}
