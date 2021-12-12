using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ParticleSystem))]
public class BulletView : MonoBehaviour
{
    private BulletController bulletController;

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
}
