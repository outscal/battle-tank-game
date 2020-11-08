using UnityEngine;
using ScriptableObjects;
using Weapons;
using Effects;
using System.Collections;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankController : MonoBehaviour
    {
        [SerializeField]
        protected Transform chassis, turret, bulletSpawnPosition;

        private Rigidbody rb;
        private float moveSpeed, bulletSpeed;
        private int health, bulletDamage;
        private float bulletCooldownTime = 5f;
        protected bool bulletCooldownFlag = false;

        public void TankSetup(TankScriptableObject tankData)
        {
            moveSpeed = tankData.moveSpeed;
            bulletSpeed = tankData.bulletSpeed;
            health = tankData.health;
            bulletDamage = tankData.bulletDamage;
            bulletCooldownTime = tankData.bulletCooldownTime;
        }

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        protected void MoveTankForward()
        {
            rb.AddForce(chassis.transform.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        protected void ShootBullet()
        {
            if (!bulletCooldownFlag)
            {
                BulletController bullet = BulletService.Instance.CreateBullet();
                bullet.transform.position = bulletSpawnPosition.position;
                bullet.SetDamage(bulletDamage);
                bullet.Fire(turret.transform.eulerAngles, bulletSpeed);
                bulletCooldownFlag = true;
                StartCoroutine(StartBulletCooldown());
            }

        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                DestroyTank();
            }
        }
        protected IEnumerator StartBulletCooldown()
        {
            if (bulletCooldownFlag)
            {
                yield return new WaitForSeconds(bulletCooldownTime);
                bulletCooldownFlag = false;
            }
            yield return null;
        }
        void DestroyTank()
        {
            Destroy(this.gameObject);
            EffectController tankExplosion = EffectService.Instance.CreateEffect(EffectType.tankExposionEffect);
            tankExplosion.playEffect(transform.position);
        }
    }
}
