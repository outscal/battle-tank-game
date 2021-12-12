using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public BulletView BulletView;
    public BulletScriptableObjectList BulletList;

    public void FireBullet(BulletType bulletType, Transform bulletTransform)
    {
        CreateBullet(bulletType);
        //Projectile motion
    }

    private BulletController CreateBullet(BulletType bulletType)
    {
        foreach (BulletScriptableObject bullet in BulletList.BulletTypeList)
        {
            if(bullet.BulletType == bulletType)
            {
                BulletModel bulletModel = new BulletModel(BulletList.BulletTypeList[(int)bulletType].Damage, BulletList.BulletTypeList[(int)bulletType].Speed);
                BulletController bulletController = new BulletController(bulletModel, BulletView);
                return bulletController;
            }
        }
        return null;
    }
}
