using UnityEngine;

namespace BulletServices
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;

        public ParticleSystem explosionParticles;
        public AudioSource explosionSound;

        public LayerMask layerMask;

        public void SetBulletController(BulletController controller)
        {
            bulletController = controller;
        }

        private void Start()
        {
            Destroy(gameObject, bulletController.bulletModel.maxLifeTime);
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
