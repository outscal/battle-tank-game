using GlobalServices;
using UnityEngine;

namespace BulletServices
{
    // Script is present on visual instance of bullet.
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;

        public ParticleSystem explosionParticles;
        public AudioSource explosionSound;    

        // To set bullet controller reference in bullet view.
        public void SetBulletController(BulletController controller)
        {
            bulletController = controller;
        }

        private void Start()
        {
            EventService.Instance.OnGamePaused += bulletController.GamePaused;
            EventService.Instance.OnGameResumed += bulletController.GameResumed;
        }

        private void OnDestroy()
        {
            EventService.Instance.OnGamePaused -= bulletController.GamePaused;
            EventService.Instance.OnGameResumed -= bulletController.GameResumed;         
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
