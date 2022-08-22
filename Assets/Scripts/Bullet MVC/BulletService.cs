using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletScriptableObjects;

/// <summary>
/// This Class is responsible to Create, Destroy & Manage all the Bullet MVCs in the game.
/// </summary>

namespace BulletServices {
    // Handles spawning of bullet and communication of bullet service with other services.
    public class BulletService : GenericSingleton<BulletService>
    {
        public BulletScriptableObjectList bulletSOList;

        // Spawns specified type of bullet at given position and sets its velocity as per launch force. 
        private BulletController CreateBullet(BulletType bulletType, Transform bulletTransform, float launchForce)
        {
            foreach (BulletScriptableObject bullet in bulletSOList.bulletScriptableObjectList)
            {
                if (bullet.bulletType == bulletType)
                {
                    BulletModel bulletModel = new BulletModel(bulletSOList.bulletScriptableObjectList[(int)bulletType].damage,
                                                              bulletSOList.bulletScriptableObjectList[(int)bulletType].maxLifeTime);

                    BulletController bulletController = new BulletController(bulletModel, bulletSOList.bulletScriptableObjectList[(int)bulletType].bulletView, bulletTransform, launchForce);
                    return bulletController;
                }
            }
            return null;
        }
    }
}