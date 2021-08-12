using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    public class BulletService : GenericSingletone<BulletService>
    {
        //[SerializeField] private BulletView bulletView;
        [SerializeField] private BulletScriptableObject bulletScriptableObject;
        void Start()
        {
            StartGame();
        }

        void StartGame()
        {
            CreateNewBullet();
        }

        private BulletController CreateNewBullet()
        {  
            //BulletView bulletView = gameObject.GetComponent<BulletView>();
            //BulletModel model = new BulletModel(BulletType.None, 5);
            //BulletController bullet = new BulletController(model, bulletView);
            //return bullet;

            BulletModel bulletModel = new BulletModel(bulletScriptableObject);
            BulletView bulletView = bulletScriptableObject.BulletView;
            //TankModel model = new TankModel(TankType.None, 5, 100f);
            BulletController bullet = new BulletController(bulletModel, bulletView);
            return bullet;
        }
    }
}