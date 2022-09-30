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
    }

}
