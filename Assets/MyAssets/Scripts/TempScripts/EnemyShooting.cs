using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public ParticleSystem m_ExplosionParticles;
    public float bulletForce = 10f;
    private float canFire = 0f;
    private float fireRate = 0.5f;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        StartCoroutine(PlayShootEffect());
        // m_ExplosionParticles.Play();
        // Debug.Log(canFire);
        canFire = fireRate + Time.time;
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firepoint.forward * bulletForce, ForceMode.Impulse);

    }

    IEnumerator PlayShootEffect()
    {
        m_ExplosionParticles.Play();
        yield return new WaitForSeconds(0.4f);
        m_ExplosionParticles.Stop();
    }
}
