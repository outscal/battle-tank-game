using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyTankRangeCollider : MonoBehaviour
{

    public Transform PlayerTransform { get; private set; }

    // This Class is used for checking if Player is in range to be chased
    void OnTriggerEnter(Collider collider)
    {
        PlayerTankView playerTankView = collider.GetComponent<PlayerTankView>();
        playerTankView = playerTankView != null ? playerTankView : collider.GetComponentInParent<PlayerTankView>();

        if (playerTankView != null)
        {
            EnemyTankView enemyTankView = gameObject.GetComponentInParent<EnemyTankView>();
            if (enemyTankView != null)
            {
                PlayerTransform = playerTankView.gameObject.transform;
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