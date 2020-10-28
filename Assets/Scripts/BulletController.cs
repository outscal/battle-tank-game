using UnityEngine;
using Effects;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletController : MonoBehaviour
    {
        private Rigidbody rb;
        [SerializeField]
        private float bulletRange;
        private Vector3 spawnPos;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Vector3.Distance(spawnPos, transform.position) > bulletRange)
            {
                Destroy(this.gameObject);
            }
        }
        public void Fire(Vector3 eulerAngle, float shootSpeed)
        {
            transform.eulerAngles = eulerAngle;
            rb.AddForce(transform.forward * shootSpeed);
            spawnPos = transform.position;
        }
        private void OnCollisionEnter(Collision collision)
        {
            ParticleSystem shellExplosion=  EffectService.Instance.CreateEffect(EffectType.shellExplosionEffect);
            shellExplosion.transform.position = collision.contacts[0].point;
            shellExplosion.Play();
            Destroy(this.gameObject);
        }
    }
}
