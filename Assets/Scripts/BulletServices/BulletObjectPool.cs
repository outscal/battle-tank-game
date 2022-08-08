using GlobalServices;
using UnityEngine;

namespace BulletServices
{
    public class BulletObjectPool : ObjectPoolService<BulletController>
    {
        protected override BulletController CreateItem()
        {
            int rand = Random.Range(0, BulletService.Instance.bulletList.bulletTypes.Length);
            BulletController bulletController = BulletService.Instance.FireBullet((BulletType)rand, transform, 0f);

            return bulletController;
        }
    }
}
