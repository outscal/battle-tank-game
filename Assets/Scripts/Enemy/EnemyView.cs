using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyController EnemyController { get; set; }

    // Implement visual aspects of the enemy here
    private void Start()
    {
        Debug.Log("Enemy view created!");
        AssetManager.Instance.AddEnemyView(this);
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        EnemyController = _enemyController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ShellView>())
        {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        GameObject explosion = Instantiate(EnemyController.GetEnemyModel().Explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(explosion, 1.5f);
        AssetManager.Instance.RemoveEnemyView(this);
        Destroy(gameObject);
    }
}
