using System;
using UnityEngine;

public class TankBulletService : MonoBehaviour
{
    public TankBulletView tankBulletView;
    public TankBulletScriptableObject[] tankBUlletConfiguration;
    private static TankBulletService instance;
    public static TankBulletService Instance { get { return instance; } }

    public Action<int> bulletFiredbyPlayer;

    [SerializeField]
    private ServicePoolBullet servicePoolBullet;

    // Start is called before the first frame update

    private void Awake()
    {
      if(instance == null)
      {
           instance = this;  
      }
      else
      {
            Destroy(gameObject);
      }
    }

    void Start()
    {
        servicePoolBullet = GetComponent<ServicePoolBullet>();
    }


    public TankBulletController CreateNewBullet(Transform spawnpos)
    {
        TankBulletScriptableObject tankBulletScriptableObject = tankBUlletConfiguration[0];
        TankBulletModel model = new TankBulletModel(tankBulletScriptableObject);
        //  TankBulletController bullet = new TankBulletController(model, tankBulletView,spawnpos);
        TankBulletController bullet = servicePoolBullet.GetBullet(model,tankBulletView);
        ShootBullet(bullet, spawnpos);
        return bullet;
    }

    public ServicePoolBullet GetBulletPool()
    {
        return servicePoolBullet;
    }

    public void ShootBullet(TankBulletController tankBulletController, Transform spawnPos)
    {
        tankBulletController.ShootBullet(spawnPos);        
    }
}
