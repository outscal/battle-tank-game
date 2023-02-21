using UnityEngine;

public class TankBulletView : MonoBehaviour
{
    public TankBUlletType tankBulletType;
    public TankBulletController tankBulletController;
    
   

    public int GetDamage()
    {
        return tankBulletController.BulletDamage();
    }
    public void SetTankBulletController(TankBulletController _tankBulletController)
    {
        tankBulletController = _tankBulletController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Tank_View>(out Tank_View tank_View))
        {
            tank_View.GetTankController().tankmodel.Health = tank_View.GetTankController().tankmodel.Health - GetDamage();
            Debug.Log("health: " + tank_View.GetTankController().tankmodel.Health);
        }
        SetVisibilityStatus(false);
        ReturnBulletToPool();
    }

    public void SetVisibilityStatus(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }

    public void ReturnBulletToPool()
    {
        TankBulletService.Instance.GetBulletPool().ReturnItem(tankBulletController);
    }
}
