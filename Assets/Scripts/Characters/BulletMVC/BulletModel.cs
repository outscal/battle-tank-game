public class BulletModel
{
    private BulletController _controller;
    private BulletScriptableObject _BscriptableObject;
    public int speed { get; }
    public int damage { get; }
    public int Duration { get; }
    public BulletType type { get; }
    public BulletModel(BulletScriptableObject bulletSo) { 
        _BscriptableObject = bulletSo;
        speed=bulletSo.speed;
        damage=bulletSo.damage;
        Duration =(int)bulletSo.duration;
        type = bulletSo.type;
    }
    public void SetBulletController(BulletController bulletController)
    {
        _controller = bulletController;
    }
    public int SpeedLive { get { return (int)_BscriptableObject.speed; } }
}
