using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletC  
{
    public BulletC(BulletSo _bullet, Transform _transform)
    {
        bulletView = GameObject.Instantiate<BulletVi>(_bullet.bulletView, _transform.position, _transform.rotation);
        bulletModel = new BulletM(_bullet);

        bulletView.SetBulletController(this);
        bulletModel.SetBulletController(this);

        rb = bulletView.GetRigidbody();
    }
    private BulletM bulletModel;
    private BulletVi bulletView;
    Rigidbody rb;
    public void Shoot()
    {

        rb.AddForce(rb.transform.forward * bulletModel.range *Time.deltaTime, ForceMode.Impulse);
=======
        rb.AddForce(rb.transform.forward * bulletModel.range, ForceMode.Impulse);

    }
    public void BulletCollision(Vector3 position)
    {
        BulletS.Instance.BulletExplosion(position, bulletView);
    }
    public int GetBulletDamage()
    {
        return bulletModel.damage;
    }
}
