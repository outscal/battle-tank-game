using BulletSO;
using GlobalServices;
using UnityEngine;

namespace BulletServices
{ 
    // Handles spawning of bullet and communication of bullet service with other services.
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public BulletSOList bulletList;

        // To fire bullet. // Returns bullet controller.
        public BulletController FireBullet(BulletType bulletType, Transform bulletTransform, float launchForce)
        {
            return CreateBullet(bulletType, bulletTransform, launchForce);
        }

        // Spawns specified type of bullet at given position and sets its velocity as per launch force. 
        private BulletController CreateBullet(BulletType bulletType, Transform bulletTransform, float launchForce)
        {
            foreach (BulletScriptableObject bullet in bulletList.bulletTypes)
            {
                if(bullet.bulletType == bulletType)
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

