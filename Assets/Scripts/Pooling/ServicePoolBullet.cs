
public class ServicePoolBullet : ServicePool<TankBulletController>
{
    private TankBulletModel tankBulletModel;
    private TankBulletView tankBulletPrefab;


    public TankBulletController GetBullet(TankBulletModel tankBulletModel, TankBulletView tankBulletPrefab)
    {
        this.tankBulletModel = tankBulletModel;
        this.tankBulletPrefab = tankBulletPrefab;
 
        return GetItem();
    }
    protected override TankBulletController CreateItem()
    {
        TankBulletController tankBulletController = new TankBulletController(tankBulletModel, tankBulletPrefab);
        return tankBulletController;
    }
}
