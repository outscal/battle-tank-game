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

    public TankBulletController CreateNewBullet(Transform spawnpos)
    {
        TankBulletScriptableObject tankBulletScriptableObject = tankBUlletConfiguration[0];
        TankBulletModel model = new TankBulletModel(tankBulletScriptableObject);
        TankBulletController bullet = new TankBulletController(model, tankBulletView,spawnpos);
        return bullet;
    }
}
