using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBulletService : MonoBehaviour
{
    public TankBulletView tankBulletView;
    public TankBulletScriptableObject[] tankBUlletConfiguration;
    private static TankBulletService instance;
    public static TankBulletService Instance { get { return instance; } }

    // Start is called before the first frame update

    private void Awake()
    {
      if(instance == null)
        {
            instance = this;
            Debug.Log("Hello Vimarsh");
        }
      else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
      //  CreateNewBullet();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if
    //}

    //void SpwanBullet()
    //{

    //    // int enemyToSpwan = Random.Range(1, 3);

    //    //  Debug.Log("Enemy number" + enemyToSpwan);
    //    CreateNewBullet();
    //}

    public TankBulletController CreateNewBullet(Transform spawnpos)
    {
        TankBulletScriptableObject tankBulletScriptableObject = tankBUlletConfiguration[0];
        TankBulletModel model = new TankBulletModel(tankBulletScriptableObject);
        TankBulletController bullet = new TankBulletController(model, tankBulletView,spawnpos);
        return bullet;
    }
}
