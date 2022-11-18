using AllServices;
using UnityEngine;

namespace BulletServices
{
    public class BulletObjectPool : ObjectPoolingService<BulletController>
    {
        protected override BulletController CreateItem()
        {
            int rand = Random.Range(0, BulletService.Instance.bulletSOList.bulletScriptableObjectList.Length);
            BulletController bulletController = BulletService.Instance.FireBullet((BulletType)rand, transform, 0f);

            return bulletController;
        }
    }
}
