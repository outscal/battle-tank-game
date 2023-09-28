using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyController EnemyController { get; set; }

    // Implement visual aspects of the enemy here
    private void Start()
    {
        Debug.Log("Enemy view created!");
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        EnemyController = _enemyController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ShellView>())
        {
            DestroyTank();
        }
    }

    public void DestroyTank()
    {
        GameObject explosion = Instantiate(EnemyController.GetEnemyModel().Explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(explosion, 1.5f);
        Destroy(gameObject);
    }
}
