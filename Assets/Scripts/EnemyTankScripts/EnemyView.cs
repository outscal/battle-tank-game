using UnityEngine;

public class EnemyView : MonoBehaviour, IDamageable
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
    public int GetEnemyStrength()
    {
        return enemyController.GetStrength();
    }
    public void TakeDamage(int damage)
    {
        enemyController.TakeDamage(damage);
    }
}
