using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController { get; private set; }

        public GameObject BullectDestroyVFX;
        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }


        public Transform firepoint;
        public GameObject bulletPrefab;
        public ParticleSystem m_ExplosionParticles;
        public float bulletForce = 10f;
        private float canFire = 0f;
        public float fireRate = 5f;

        void Update()
        {
            Shoot();
        }

        void Shoot()
        {
            if (Input.GetButtonDown("Fire1") && canFire < Time.time)
            {
                StartCoroutine(PlayShootEffect());
                // m_ExplosionParticles.Play();
                // Debug.Log(canFire);
                canFire = fireRate + Time.time;
                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(firepoint.forward * bulletForce, ForceMode.Impulse);
            }
        }

        IEnumerator PlayShootEffect()
        {
            m_ExplosionParticles.Play();
            yield return new WaitForSeconds(0.4f);
            m_ExplosionParticles.Stop();

        }


    }
}