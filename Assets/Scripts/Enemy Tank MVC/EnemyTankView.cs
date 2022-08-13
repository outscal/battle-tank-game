using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankView :MonoBehaviour
{
    public EnemyTankController enemyTankController;
    [HideInInspector]
    public Transform playerTransform;

    public void SetTankControllerReference(EnemyTankController enemyController)
    {
        enemyTankController = enemyController;
    }

    private void Start()
    {
        if (TankService.Instance.tankController.tankView)
        {
            playerTransform = TankService.Instance.tankController.tankView.transform;
        }
    }
}
