using TankBattle.Tank.PlayerTank.MoveController;
using UnityEngine;

namespace TankBattle.Tank.Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShellView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionParticles;

        private ShellController shellController;
        private AudioSource explosionAudio;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            explosionAudio = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Destroy(gameObject, CreateShellService.Instance.GetBulletModel.MaxLifeTime);
        }

        public void SetShellController(ShellController _shellController)
        {
            shellController = _shellController;
        }

        public Rigidbody GetRigidbody()
        {
            return rb;
        }

        public AudioSource GetAudioSystem()
        {
            return explosionAudio;
        }

        public ParticleSystem GetParticleSystem()
        {
            return explosionParticles;
        }

        public void AddVelocity(Vector3 velocityVector)
        {
            rb.velocity = velocityVector;
        }

        // main function -
        // find only tank colliders in a sphere area around the shell and give damage
        // according to its distance away from it.
        private void OnTriggerEnter(Collider other)
        {
            int maxColliders = 10;
            Collider[] hitColliders = new Collider[maxColliders];
            int numOfColliders = Physics.OverlapSphereNonAlloc(transform.position, CreateShellService.Instance.GetBulletModel.ExplosionRadius, hitColliders, CreateShellService.Instance.GetBulletModel.LayerMask);

            shellController.CheckHitColliders(hitColliders, numOfColliders, transform.position);
            DestroyBullet();
        }

        private void DestroyBullet()
        {
            explosionParticles.transform.parent = null;
            explosionParticles.Play();
            explosionAudio.Play();
            Destroy(explosionParticles.gameObject, explosionParticles.main.duration);
            Destroy(gameObject);
        }
    }
}