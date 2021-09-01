using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    [RequireComponent(typeof(EnemyTankView))]
    public class EnemyTankState : MonoBehaviour
    {
        public static EnemyTankView enemyTankView;
        public virtual void OnEnterState() 
        {
            this.enabled = true;
        }
        public virtual void OnExitState()
        {
            this.enabled = false;
        }
    }
}