using UnityEngine;

namespace BulletServices
{
    public class FireButtonController : GenericSingleton<FireButtonController>
    {
        public BulletController CreateBullet()
        {
            int rand = Random.Range(0, BulletService.Instance.bulletSOList.bulletScriptableObjectList.Length);
            BulletController bulletController = BulletService.Instance.FireBullet((BulletType)rand, transform, 0f);

            return bulletController;
        }
    }
}
