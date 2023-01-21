using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public BulletScriptableObjectList bulletScriptableObjectList;
    public BulletModel bulletModel;
    public BulletService(BulletScriptableObjectList _bulletScriptableObjectList)
    {
        bulletScriptableObjectList = _bulletScriptableObjectList;
    }



    public void Start()
    {
        int randomBulletIndex = Random.Range(0, bulletScriptableObjectList.BulletList.Length);
        BulletScriptableObject bulletScriptableObject = bulletScriptableObjectList.BulletList[randomBulletIndex];
        bulletModel = new BulletModel(bulletScriptableObject);


    }

    public void SpawnBullet(Transform bulletSpawnPoint, Quaternion rotation)
    {
        BulletScriptableObject bulletScriptableObject = GetBulletScriptableObject(bulletModel.bulletType);
        if (bulletScriptableObject != null)
        {
            GameObject bullet = Instantiate(bulletScriptableObject.prefab, bulletSpawnPoint.position, rotation);
            BulletView bulletView = bullet.GetComponent<BulletView>();

            bulletView.BulletParticleEffect = bulletScriptableObject.BulletParticleEffect;
            
            
            //bulletView.GetComponent<Renderer>().enabled = true;

            // Instantiate the BulletController and set the bulletModel property
            BulletController bulletController = new BulletController(bulletModel, bulletView);

            // Set the bulletController property on the bulletView
            bulletView.SetBulletController(bulletController);

            

            EnemyView enemyView = new EnemyView();
            bulletView.SetEnemyView(enemyView);
            PlayerTankView playerTankView = new PlayerTankView();
            bulletView.SetPlayerTankView(playerTankView);

            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(bullet.transform.forward * bulletModel.bulletSpeed, ForceMode.Impulse);
        }

        Debug.Log(bulletModel.bulletType + "Bullet Spawned");
    }




    private BulletScriptableObject GetBulletScriptableObject(BulletType bulletType)
    {
        // Iterate through the list of bullet scriptable objects and return the one that matches the bulletType
        for (int i = 0; i < bulletScriptableObjectList.BulletList.Length; i++)
        {
            if (bulletScriptableObjectList.BulletList[i].bulletType == bulletType)
            {
                return bulletScriptableObjectList.BulletList[i];
            }
        }
        return null;
    }
}

