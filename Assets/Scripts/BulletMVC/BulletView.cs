using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    public void SetBulletViewController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    private void Start()
    {
        if(bulletController!=null)
            bulletController.UpdateBulletMovement();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(bulletController!=null)
        {
            bulletController.CheckEnemy(col);
            bulletController.DestroyBullet(col);
        }
        
    }

}
