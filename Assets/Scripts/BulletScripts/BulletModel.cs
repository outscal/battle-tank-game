using UnityEngine;

public class BulletModel
{
    BulletController bulletController;
    public BulletModel(int _damage, int _speed)
    {
        damage = _damage;
        speed = _speed;
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    public int damage { get; }
    public int speed { get; }
}
