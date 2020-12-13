using UnityEngine;
using Effects;
using Tank;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletController : MonoBehaviour
    {
        private Rigidbody rb;
        private Vector3 spawnPos;
        private int bulletDamage;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        public void SetDamage(int damage)
        {
            bulletDamage = damage;
        }

        public void Fire(Vector3 eulerAngle, float shootSpeed)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.eulerAngles = eulerAngle;
            rb.AddForce(transform.forward * shootSpeed);
            spawnPos = transform.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            ShowShellExplosion(collision.contacts[0].point);
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                DamageObject(damageable);
            }
            BulletService.Instance.AddBulletToPool(this);
        }

        void ShowShellExplosion(Vector3 pos)
        {
            EffectController shellExplosion = EffectService.Instance.CreateEffect(EffectType.shellExplosionEffect);
            shellExplosion.playEffect(pos);
        }

        void DamageObject(IDamageable damageable)
        {
            damageable.TakeDamage(bulletDamage);
        }

    }
}
