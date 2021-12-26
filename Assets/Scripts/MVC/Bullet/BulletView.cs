using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletView : MonoBehaviour
{
    private BulletController bulletController;

    public ParticleSystem ExplosionParticles;
    public AudioSource ExplosionSound;

    public LayerMask LayerMask;

    public void SetBulletController(BulletController controller)
    {
        bulletController = controller;
    }

    private void Start()
    {
        //Destroy(gameObject, bulletController.BulletModel.MaxLifeTime);
    }

    private void FixedUpdate()
    {
        if(bulletController != null)
        {
            bulletController.FixedUpdateBulletController();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bulletController.OnCollisionEnter(other);
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void DestroyParticleSystem(ParticleSystem particles)
    {
        Destroy(particles.gameObject, particles.main.duration);
    }
}
