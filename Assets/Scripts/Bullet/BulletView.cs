using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public class BulletView : MonoBehaviour, IgetController
{
    private BulletController bulletController;
    public Rigidbody bulletRb = new Rigidbody();

    private void Start()
    {
        gameObject.GetComponent<MeshCollider>().convex = true;
        bulletRb = gameObject.GetComponent<Rigidbody>();
    }
    public void getTankController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        bulletController.onHit();
    }


}
