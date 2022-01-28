using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MVC.Tank
{
    public class BulletService : MonoBehaviour
    {
        public BulletView BulletView;
        public BulletScriptableObject[] bulletConfigurations;

        public void FireBullet(BulletType bulletType)
        {
            CreateBullet(bulletType);
        }

        private BulletController CreateBullet(BulletType BulletType)
        {
            BulletController bulletController;
            //return bulletController;
            return null;
        }

        private void Start()
        {
            BulletScriptableObject bulletScriptableObject = bulletConfigurations[Random.Range(0,2)];
            BulletModel model = new BulletModel(bulletScriptableObject);
            BulletController Bullet = new BulletController(model, BulletView);
        }

    }
}