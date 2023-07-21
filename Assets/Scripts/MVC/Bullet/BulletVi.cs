using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVi : MonoBehaviour
{
    BulletC bulletController;
    [SerializeField] Rigidbody rb;
    void Start()
    {
        bulletController.Shoot();
    }
    public void SetBulletController(BulletC _bulletController)
    {
        bulletController = _bulletController;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    /*void OnCollisionEnter(Collision col)
    {
        bulletController.BulletCollision(col.contacts[0].point);
        IDamageable target = col.gameObject.GetComponent<IDamageable>();
        if (target != null)
        {
            target.TakeDamage(bulletController.GetBulletDamage());
        }
    }*/
}
