using UnityEngine;
using ScriptableObjects;
using Weapons;
using Effects;
using System.Collections;
using Game;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankController : MonoBehaviour,IDamageable
    {
        [SerializeField]
        protected Transform chassis, bulletSpawnPosition;
        public Transform turret;
        private Rigidbody rb;
        private float moveSpeed, bulletSpeed;
        private int health, bulletDamage;
        private float bulletCooldownTime = 5f;
        protected bool bulletCooldownFlag = false;

        Vector3 startPos;
        TankScriptableObject myTankData;

        public void TankSetup(TankScriptableObject tankData)
        {
            moveSpeed = tankData.moveSpeed;
            bulletSpeed = tankData.bulletSpeed;
            health = tankData.health;
            bulletDamage = tankData.bulletDamage;
            bulletCooldownTime = tankData.bulletCooldownTime;
            startPos = transform.position;
            myTankData = tankData;
        }

        private void OnEnable()
        {
            SetBulletCountdown();
        }
        private void SetBulletCountdown()
        {
            bulletCooldownFlag = true;
            StartCoroutine(StartBulletCooldown());
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
                BulletController bullet = BulletService.Instance.GetBulletFromPool();
                bullet.gameObject.SetActive(true);
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

        private void DestroyTank()
        {
            EffectController tankExplosion = EffectService.Instance.CreateEffect(EffectType.tankExposionEffect);
            tankExplosion.playEffect(transform.position);
            if (this.gameObject.CompareTag("Player"))
            {
                GameController.GC.SetPlayerDeath();
            }
            else
            {
                TankService.Instance.DestroyTank(this);
            }
        }
        public void ResetTankValues()
        {
            TankSetup(myTankData);
        }

    }
}
