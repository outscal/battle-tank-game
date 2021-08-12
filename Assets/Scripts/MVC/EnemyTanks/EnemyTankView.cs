using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    public class EnemyTankView : MonoBehaviour
    {
        private EnemyTankController EnemyTankController;
        [SerializeField] private EnemyTankType EnemyTankType;

        private void Start()
        {
            Debug.Log("view created");
        }

    }
}