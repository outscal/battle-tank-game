using UnityEngine;

public class TankBulletView : MonoBehaviour
{
  //public TankBulletController tankBulletController;
    public TankBUlletType tankBulletType;
    public TankBulletController tankBulletController;
   
  
    

    


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetDamage()
    {
        return tankBulletController.BulletDamage();
    }
    public void SetTankBulletController(TankBulletController _tankBulletController)
    {
        tankBulletController = _tankBulletController;
    }
}
