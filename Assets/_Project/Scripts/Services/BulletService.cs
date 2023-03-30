using UnityEngine;

namespace BattleTank
{
    public class BulletService : GenericSingleton<BulletService>
    {
        [SerializeField] private BulletView bulletView;
        private BulletController bulletController;

        [SerializeField] private BulletScriptableObjectList bulletList;
        
        public void SpawnBullet(BulletType bulletType, Transform transform, Quaternion quaternion)
        {
            Debug.Log(bulletList.bullets[GetBulletIndex(bulletType)].name);
            new BulletController(new BulletModel(bulletList.bullets[GetBulletIndex(bulletType)]), bulletView, transform, quaternion);
        }

        private int GetBulletIndex(BulletType bulletType)
        {
            int bIndex = 0;
            for(int i = 0; i < bulletList.bullets.Length; i++)
            {
                if(bulletList.bullets[i].BulletType == bulletType)
                {
                    bIndex = i;
                }
            }
            return bIndex;
        }
    }
}