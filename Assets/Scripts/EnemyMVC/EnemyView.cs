
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;

    public void LinkController(EnemyController _enemyController)
    {
        enemyController = _enemyController ;
    }

    private void Update()
    {
        enemyController.Patrol(gameObject.transform.position) ;
    }
}
