
using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController enemyTankController;
    public void SetEnemyTankController(EnemyTankController tankController)
    {
        enemyTankController = tankController;
    }
    private void OnCollisionEnter(Collision collision)
    {
        BulletView bulletView = collision.gameObject.GetComponent<BulletView>();
        if (bulletView == null)
            return;
        enemyTankController.TakeDamage(bulletView.power);

    }
}
