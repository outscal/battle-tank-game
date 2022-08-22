using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankServices;

namespace EnemyTankServices
{
    public class EnemyTankView : MonoBehaviour
    {
        public EnemyTankController enemyTankController;
        [HideInInspector] public Transform playerTransform;

        public void SetTankControllerReference(EnemyTankController enemyController)
        {
            enemyTankController = enemyController;
        }

        private void Start()
        {

            // If player is spawnned, we take reference of player transform.
            if (TankService.Instance.playerTankView)
            {
                playerTransform = TankService.Instance.playerTankView.transform;
            }
            SetEnemyTankColor();
        }

        // Sets material color of all child mesh renderers.
        public void SetEnemyTankColor()
        {
            MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = enemyTankController.enemyTankModel.TankColor;
            }
        }
    }
}
