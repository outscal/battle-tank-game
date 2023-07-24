using UnityEngine;

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
    public override void ReturnItem(BulletController bulletController)
    {
        base.ReturnItem(bulletController);
        bulletController.BulletView.gameObject.SetActive(false);
    }
}
