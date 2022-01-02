using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    public ParticleSystem explosionParticles;
    public AudioSource explosionAudio;
    public LayerMask tankMask;

    public void SetBulletController(BulletController controller)
    {
        bulletController = controller;
    }
    void Start()
    {
        Debug.Log("Bullet is Created");
    }

    private void OnTriggerEnter(Collider other)
    {
        bulletController.OnCollisionEnter(other);
    }
    public void DestroyParticleSystem(ParticleSystem particles)
    {
        Destroy(particles.gameObject, particles.main.duration);
    }
    public void DestroyBullet()
    {
        Destroy(gameObject, 1f);
    }
}