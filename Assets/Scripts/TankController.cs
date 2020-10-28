using UnityEngine;
using ScriptableObjects;
using Weapons;

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

        public void TankSetup(TankScriptableObject tankData)
        {
            moveSpeed = tankData.moveSpeed;
            bulletSpeed = tankData.bulletSpeed;
            health = tankData.health;
            bulletDamage = tankData.bulletDamage;
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
            BulletController bullet = BulletService.Instance.CreateBullet();
            bullet.transform.position = bulletSpawnPosition.position;
            bullet.Fire(turret.transform.eulerAngles, bulletSpeed);
        }
    }
}
