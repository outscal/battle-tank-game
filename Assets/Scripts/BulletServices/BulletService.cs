using BulletScriptables;
using GlobalServices;
using UnityEngine;

namespace BulletServices
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public BulletSOList bulletList;

        public void FireBullet(BulletType bulletType, Transform bulletTransform, float launchForce)
        {
            CreateBullet(bulletType, bulletTransform, launchForce);
        }

        private BulletController CreateBullet(BulletType bulletType, Transform bulletTransform, float launchForce)
        {
            foreach (BulletScriptableObject bullet in bulletList.bulletTypes)
            {
                if (bullet.bulletType == bulletType)
                {
                    BulletModel bulletModel = new BulletModel(bulletList.bulletTypes[(int)bulletType].damage,
                                                              bulletList.bulletTypes[(int)bulletType].maxLifeTime,
                                                              bulletList.bulletTypes[(int)bulletType].explosionRadius,
                                                              bulletList.bulletTypes[(int)bulletType].explosionForce);

                    BulletController bulletController = new BulletController(bulletModel, bulletList.bulletTypes[(int)bulletType].bulletView, bulletTransform, launchForce);
                    return bulletController;
                }
            }
            return null;
        }
    }
}

