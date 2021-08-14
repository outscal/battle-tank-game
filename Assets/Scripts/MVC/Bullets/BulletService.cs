using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// handling bullet services
    /// </summary>
    //public class BulletService : GenericMonoSingletone<BulletService>
    public class BulletService : MonoSingleton<BulletService>

    {
        //creating bullet
        public void CreateNewBullet(Vector3 position, Quaternion rotation, BulletScriptableObject type)
        {
            BulletScriptableObject bullet = type;
            BulletModel bulletModel = new BulletModel(bullet);
            BulletController bulletController = new BulletController(bullet.BulletView, bulletModel, position, rotation);
        }
        ////[SerializeField] private BulletView bulletView;
        //[SerializeField] private BulletScriptableObject bulletScriptableObject;
        //void Start()
        //{
        //    StartGame();
        //}

        //void StartGame()
        //{
        //    CreateNewBullet();
        //}

        //private BulletController CreateNewBullet()
        //{  
        //    //BulletView bulletView = gameObject.GetComponent<BulletView>();
        //    //BulletModel model = new BulletModel(BulletType.None, 5);
        //    //BulletController bullet = new BulletController(model, bulletView);
        //    //return bullet;

        //    BulletModel bulletModel = new BulletModel(bulletScriptableObject);
        //    BulletView bulletView = bulletScriptableObject.BulletView;

        //    //TankModel model = new TankModel(TankType.None, 5, 100f);

        //    BulletController bullet = new BulletController(bulletModel, bulletView);
        //    return bullet;
        //}

    }
}