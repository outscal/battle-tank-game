
public class BulletPoolService : PoolService<BulletController>
{

    public BulletController GetBullet()
    {
        return GetItem();
    }
    protected override BulletController CreateItem()
    {
        BulletController bulletControler = new(BulletService.Instance.BulletModel, BulletService.Instance.BulletPrefab);
        return bulletControler;
    }
}
