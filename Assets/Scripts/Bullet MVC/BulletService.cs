using UnityEngine;
using BulletScriptableObjects;

/// <summary>
/// This Class is responsible to Create, Destroy & Manage all the Bullet MVCs in the game.
/// </summary>

namespace BulletServices {
    public class BulletService : GenericSingleton<BulletService>
    {
        public BulletScriptableObjectList bulletSOList;

        public BulletController FireBullet(BulletType bulletType, Transform bulletTransform, float launchForce)
        {
            return CreateBullet(bulletType, bulletTransform, launchForce);
        }

        private BulletController CreateBullet(BulletType bulletType, Transform bulletTransform, float launchForce)
        {
            foreach (BulletScriptableObject bullet in bulletSOList.bulletScriptableObjectList)
            {
                if (bullet.bulletType == bulletType)
                {
                    BulletModel bulletModel = new BulletModel(bulletSOList.bulletScriptableObjectList[(int)bulletType].damage,
                                                              bulletSOList.bulletScriptableObjectList[(int)bulletType].maxLifeTime,
                                                              bulletSOList.bulletScriptableObjectList[(int)bulletType].radiousOfExplosion,
                                                              bulletSOList.bulletScriptableObjectList[(int)bulletType].forceOfExplosion);

                    BulletController bulletController = new BulletController(bulletModel, bulletSOList.bulletScriptableObjectList[(int)bulletType].bulletView, bulletTransform, launchForce);
                    return bulletController;
                }
            }
            return null;
        }
    }
}