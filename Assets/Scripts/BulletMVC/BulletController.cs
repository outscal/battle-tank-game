using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    BulletModel bulletModel;
    BulletView bulletView;
    public BulletController(BulletView _bulletView , BulletModel _bulletModel)
    {
        bulletModel = _bulletModel;
        bulletView = GameObject.Instantiate<BulletView>(_bulletView, bulletModel.BulletTransform.position, bulletModel.BulletTransform.rotation);
        bulletView.SetBulletViewController(this);
        bulletModel.SetBulletController(this);
    }

    public void UpdateBulletMovement()
    {
        bulletView.gameObject.GetComponent<Rigidbody>().AddForce(bulletModel.BulletTransform.forward 
            * bulletModel.BulletSpeed);
    }
    public void DisableBullet (Collision col)
    {
        if(col.gameObject.GetComponent<TankView>()==null)
        {
            bulletView.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            bulletView.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            bulletView.gameObject.GetComponent<MeshRenderer>().enabled = false;
            bulletView.gameObject.GetComponent<ParticleSystem>().Play();
        }
    }


    public void DestroyBullet()
    {
        GameObject.Destroy(bulletView.gameObject);
    }

}
