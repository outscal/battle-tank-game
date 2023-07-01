
using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    public EnemyTankController tankController;
    public void SetEnemyTankController(EnemyTankController tankController)
    {
        this.tankController = tankController;

    }
    private void OnCollisionEnter(Collision collision)
    {
        BulletView bulletView = collision.gameObject.GetComponent<BulletView>();
        if (bulletView == null)
            return;


    }
}
