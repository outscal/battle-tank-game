using BattleTank.Bullet;
using BattleTank.BulletSO;
using BattleTank.Enum;
using BattleTank.GenericSingleton;
using UnityEngine;

namespace BattleTank.Services
{
    public class BulletService : GenericSingleton<BulletService>
    {
        [SerializeField] private BulletView bulletView;
        private BulletController bulletController;

        [SerializeField] private BulletScriptableObjectList bulletList;
        
        public void SpawnBullet(BulletType bulletType, Transform bulletTransform, Quaternion tankRotation, TankID tankID)
        {
            new BulletController(new BulletModel(bulletList.Bullets[GetBulletIndex(bulletType)]), bulletView, bulletTransform, tankRotation, tankID);
        }

        private int GetBulletIndex(BulletType bulletType)
        {
            int bulletIndex = 0;
            for(int i = 0; i < bulletList.Bullets.Length; i++)
            {
                if(bulletList.Bullets[i].BulletType == bulletType)
                {
                    bulletIndex = i;
                }
            }
            return bulletIndex;
        }
    }
}