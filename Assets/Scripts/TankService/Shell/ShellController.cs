using UnityEngine;

/*
 *  Shell Script Bullet
 *  Handling the logic for a bullets collisions, using overlapSphereNonAlloc to check for colliders with layer mask of tank
 *  Converting to MVC - 
 *  
 */

namespace TankBattle.TankService.Bullets
{
    public class ShellController : MonoBehaviour
    {
        [SerializeField] private ShellScriptableObject shellScriptableObject;

        private ShellModel shellModel;
        private ParticleSystem explosionParticles;
        private AudioSource explosionAudio;

        private void Awake()
        {
            shellModel = new ShellModel(shellScriptableObject);
            explosionParticles = shellScriptableObject.shellView.GetParticleSystem();
            explosionAudio = shellScriptableObject.shellView.GetAudioSystem();
        }

        // Start is called before the first frame update
        private void Start()
        {
            Destroy(gameObject, shellModel.MaxLifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            // main function - find only tank colliders in a sphere area around the shell and give damage
            // according to its distance away from it.

            //Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);

            int maxColliders = 100;
            Collider[] hitColliders = new Collider[maxColliders];
            int numOfColliders = Physics.OverlapSphereNonAlloc(transform.position, shellModel.ExplosionRadius, hitColliders, shellModel.LayerMask);

            checkHitColliders(hitColliders, numOfColliders);

            // unparent particle from shell which will be destroyed
            // before deleting bullet

            destroyBullet();
        }

        private void destroyBullet()
        {
            //explosionParticles.transform.parent = null;

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
            // calculate amount of damage a target should take depending on its position how far away it is from tranform.position of shell/bullet
            // check without sqrt
            float explosionDistance = Vector3.Distance(targetPosition, transform.position);
            float relativeDistance = (shellModel.ExplosionRadius - explosionDistance) / shellModel.ExplosionRadius;
            float damage = relativeDistance * shellModel.MaxDamage;
            damage = Mathf.Max(damage, 0f);
            return damage;
        }
    }
}
