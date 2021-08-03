using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy tank inherited from MonoSingletonGeneric class.
/// </summary>
namespace Outscal.BattleTank3DProject
{
    public class EnemyTank : MonoSingletonGeneric<EnemyTank>
    {
        protected override void Awake()
        {
            base.Awake();
            // Custom logic 
            Debug.Log("Enemy Tank");
        }
    }
}