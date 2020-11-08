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
            transform.eulerAngles = eulerAngle;
            rb.AddForce(transform.forward * shootSpeed);
            spawnPos = transform.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            ShowShellExplosion(collision.contacts[0].point);
            if (collision.gameObject.GetComponent<TankController>() != null)
            {
                DamageTank(collision.gameObject.GetComponent<TankController>());
            }
            Destroy(this.gameObject);
        }

        void ShowShellExplosion(Vector3 pos)
        {
            EffectController shellExplosion = EffectService.Instance.CreateEffect(EffectType.shellExplosionEffect);
            shellExplosion.playEffect(pos);
        }

        void DamageTank(TankController tank)
        {
            tank.TakeDamage(bulletDamage);
        }

    }
}
