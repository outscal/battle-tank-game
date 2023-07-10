using UnityEngine;

public class BulletModel
{
    BulletController bulletController;
    public BulletModel(BulletScriptableObject _bullet)
    {
        roundsPerMinute = _bullet.roundsPerMinute;
        damage = _bullet.damage;
        range = _bullet.range;
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    public void SetTankType(TankType _tankType)
    {
        tankType = _tankType;
    }
    public int damage { get; }
    public int range { get; }
    public int roundsPerMinute { get; }
    public TankType tankType { private set; get; }
}
