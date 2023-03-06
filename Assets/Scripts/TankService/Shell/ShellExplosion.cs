using UnityEngine;

namespace TankBattle.TankService.Bullets
{
    public class ShellExplosion : MonoBehaviour
    {
        [SerializeField] LayerMask tankMask;
        [SerializeField] ParticleSystem explosionParticles;
        [SerializeField] AudioSource explosionAudio;
        [SerializeField] private float maxDamage = 100f;
        [SerializeField] private float explosionForce = 1000f;
        [SerializeField] private float maxLifeTime = 2f;
        [SerializeField] private float explosionRadius = 5f;


        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, maxLifeTime);
        }


        private void OnTriggerEnter(Collider other)
        {
            // find only tank colliders in a sphere area around the shell and give damage
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRb = colliders[i].GetComponent<Rigidbody>();

                // go to next collider
                if(!targetRb) continue;

                targetRb.AddExplosionForce(explosionForce, transform.position, explosionRadius);


                // need to create a tankHealth script or use it in tankModel

                // take health value from current tank-gameObj - targetRb
                // TankHealth targetHealth = targetRb.GetComponent<TankHealth>();

                // if(!targetHealth) continue;

                float damage = CalculateDamage(targetRb.position);

                // targetHealth.TakeDamage(damage);
            }

            // unparent particle and audio source from shell which will be destroyed
            explosionParticles.transform.parent = null;
            //explosionAudio.transform.parent = null;
            explosionParticles.Play();
            explosionAudio.Play();
            Destroy(explosionParticles.gameObject, explosionParticles.main.duration);
            Destroy(gameObject);
        }

        private float CalculateDamage(Vector3 targetPosition)
        {
            // calculate amount of damage a target should take depending on its position how far away it is from tranform.position of shell/bullet

            float explosionDistance = Vector3.Distance(targetPosition, transform.position);

            float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;

            float damage = relativeDistance * maxDamage;
            damage = Mathf.Max(damage, 0f);
            return damage;
        }
    }
}
