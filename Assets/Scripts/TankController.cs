using UnityEngine;
using ScriptableObjects;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankController : MonoBehaviour
    {
        [SerializeField]
        protected Transform chassis, turret,bulletSpawnPosition;
        [SerializeField]
        private GameObject bulletPrefab;

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
            GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
            bullet.transform.eulerAngles = turret.eulerAngles;
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed);
        }

    }
}
