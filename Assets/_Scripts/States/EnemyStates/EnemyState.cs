using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyState : MonoBehaviour
    {
        internal virtual void OnEnterState()
        {
            this.enabled = true;
        }
       internal virtual void OnExitState()
        {
            this.enabled = false;
        }
    }
}