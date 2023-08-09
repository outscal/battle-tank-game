using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyTankRangeCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<PlayerTankView>() != null || collider.GetComponentInParent<PlayerTankView>() != null)
        {
            EnemyTankView enemyTankView = gameObject.GetComponentInParent<EnemyTankView>();
            if (enemyTankView != null)
            {
                enemyTankView.EnemyTankController.SetState(EnemyTankStates.Chase);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<PlayerTankView>() != null || collider.GetComponentInParent<PlayerTankView>() != null)
        {
            EnemyTankView enemyTankView = gameObject.GetComponentInParent<EnemyTankView>();
            if (enemyTankView != null)
            {
                enemyTankView.EnemyTankController.SetState(EnemyTankStates.Patrol);
            }
        }
    }
}