
using UnityEngine;

public class BulletModel : IgetController
{
    private BulletController bulletController;
    public int speed;
    public TransformSet bulletTransform;
    public bool fired = false;
    public BulletModel(int _speed, TransformSet _bulletTransform)
    {
        speed = _speed;
        bulletTransform = _bulletTransform;
    }

    public void getTankController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}
