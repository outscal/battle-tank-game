public class BulletModel
{
    BulletController bulletController;
    public BulletModel(BulletScriptableObject _bullet)
    {
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
    public TankType tankType { private set; get; }
}
