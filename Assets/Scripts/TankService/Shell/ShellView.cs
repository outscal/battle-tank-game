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
            Destroy(gameObject, shellController.GetShellModel.MaxLifeTime);
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
            int numOfColliders = Physics.OverlapSphereNonAlloc(transform.position, shellController.GetShellModel.ExplosionRadius, hitColliders, shellController.GetShellModel.LayerMask);

            checkHitColliders(hitColliders, numOfColliders);
            destroyBullet();
        }

        private void destroyBullet()
        {
            explosionParticles.transform.parent = null;
            explosionParticles.Play();
            explosionAudio.Play();
            Destroy(explosionParticles.gameObject, explosionParticles.main.duration);
            Destroy(gameObject);
        }

        private void checkHitColliders(Collider[] hitColliders, int numOfColliders)
        {
            for (int i = 0; i < numOfColliders; i++)
            {
                Rigidbody targetRb = hitColliders[i].gameObject.GetComponent<Rigidbody>();

                // go to next collider
                if (!targetRb) continue;

                targetRb.AddExplosionForce(shellController.GetShellModel.ExplosionForce, transform.position, shellController.GetShellModel.ExplosionRadius);

                // need to create a tankHealth script or use it in tankModel
                // take health value from current tank-gameObj - targetRb
                // TankHealth targetHealth = targetRb.GetComponent<TankHealth>();
                // if(!targetHealth) continue;

                float damage = shellController.CalculateDamage(targetRb.position, transform.position);
                Debug.Log($"Damage: {damage}");
                // targetHealth.TakeDamage(damage);
            }
        }
    }
}