using BattleTank.PlayerTank;
using UnityEngine;

namespace BattleTank.BulletShooting
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public BulletScriptableObject[] ConfigBullet;

        public GameObject BulletSpawner;

        public BulletController BulletController { get; private set; }

        void Start()
        {
            BulletPositionSetup();
            CreateNewBullet();
            
        }

        private BulletController CreateNewBullet()
        {
            BulletScriptableObject bulletScriptableObject = ConfigBullet[0];

            BulletModel bulletModel = new BulletModel(bulletScriptableObject);
            BulletController = new BulletController(bulletModel, bulletScriptableObject.BulletView);

            return BulletController;
        }

        public void BulletPositionSetup()
        {
            BulletSpawner.transform.SetParent(TankService.Instance.TankController.TankView.transform);
            BulletSpawner.gameObject.transform.position = new Vector3(0f, 1.52f, 0.82f);
        }
    }
}