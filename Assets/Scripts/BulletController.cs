using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletController : MonoBehaviour
    {
        Rigidbody rb;
        [SerializeField]
        private float bulletRange;
        [SerializeField]
        private ParticleSystem bulletExplosion;
        Vector3 spawnPos;

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
       
    }
}
