using UnityEngine;
public class BulletController
{
    public BulletModel bulletModel;
    private BulletView bulletView;
    

    public BulletController(BulletModel _bulletModel, BulletView _bulletView)
    {
        this.bulletModel = _bulletModel;
        this.bulletView = _bulletView;
    }
}
