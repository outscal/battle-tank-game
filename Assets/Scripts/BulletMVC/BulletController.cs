using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    BulletModel bulletModel;
    BulletView bulletView;
    public BulletController(BulletView _bulletView , BulletModel _bulletModel)
    {
        Debug.Log("it worked till here");
        bulletModel = _bulletModel;
        bulletView = GameObject.Instantiate<BulletView>(_bulletView);
        bulletView.SetBulletViewController(this);
        Debug.Log("it worked fine!!");
    }

}
