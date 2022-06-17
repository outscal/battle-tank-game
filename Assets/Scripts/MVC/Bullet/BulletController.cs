using UnityEngine;


public class BulletController
{
    public BulletView _bulletView;
    public BulletModel _bulletModel;
    public float _speed;
    public float _rotationSpeed;
    public BulletModel BulletModel { get; }
    public BulletView BulletView { get; }

    public BulletController(BulletModel bulletModel, BulletView bulletView)
    {
        _bulletModel = bulletModel;

        _speed = bulletModel.Speed;

        _bulletView = GameObject.Instantiate<BulletView>(bulletView);

        _bulletModel.SetController(this);
        _bulletView.SetController(this);

        Debug.Log("BulletView created");
    }

}
