using UnityEngine;

namespace TankBattle.Tank.Bullets
{
    public class ShellController : MonoBehaviour
    {
        [SerializeField] private ShellScriptableObject shellScriptableObject;
        //[SerializeField] private ParticleSystem explosionParticles;
        //[SerializeField] private AudioSource explosionAudio;
        public ShellModel shellModel { get; }
        public ShellView shellView { get; }

        public ShellController(ShellModel _shellModel, ShellView shellViewPrefab)
        {
            shellModel = _shellModel;
            shellView = Instantiate(shellViewPrefab);
        }

        private void Awake()
        {

        }

        // Start is called before the first frame update
        private void Start()
        {
            //Destroy(gameObject, shellModel.MaxLifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            // main function - find only tank colliders in a sphere area around the shell and give damage
            // according to its distance away from it.

            // initialize hitColliders using Physics.OverlapSphere
            int maxColliders = 10;
            Collider[] hitColliders = new Collider[maxColliders];
            int numOfColliders = Physics.OverlapSphereNonAlloc(transform.position, shellModel.ExplosionRadius, hitColliders, shellModel.LayerMask);

            checkHitColliders(hitColliders, numOfColliders);
            destroyBullet();
        }

        private void destroyBullet()
        {
            ParticleSystem explosionParticles = shellScriptableObject.shellView.GetParticleSystem();
            AudioSource explosionAudio = shellScriptableObject.shellView.GetAudioSystem();
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

                targetRb.AddExplosionForce(shellModel.ExplosionForce, transform.position, shellModel.ExplosionRadius);

                // need to create a tankHealth script or use it in tankModel
                // take health value from current tank-gameObj - targetRb
                // TankHealth targetHealth = targetRb.GetComponent<TankHealth>();
                // if(!targetHealth) continue;

                float damage = CalculateDamage(targetRb.position);

                // targetHealth.TakeDamage(damage);
            }
        }

        private float CalculateDamage(Vector3 targetPosition)
        {
            float explosionDistance = Vector3.Distance(targetPosition, transform.position);
            float relativeDistance = (shellModel.ExplosionRadius - explosionDistance) / shellModel.ExplosionRadius;
            float damage = relativeDistance * shellModel.MaxDamage;
            damage = Mathf.Max(damage, 0f);
            return damage;
        }
    }
}
