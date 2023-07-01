using UnityEngine;

public class EnemyView : MonoBehaviour
{
    EnemyController enemyController;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform gun;
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<BulletView>() != null)
        {
            BulletView bulletView = col.gameObject.GetComponent<BulletView>();
            enemyController.TakeDamage(bulletView.GetBulletDamage());
        }
    }
    public int GetEnemyStrength()
    {
        return enemyController.GetStrength();
    }
}
