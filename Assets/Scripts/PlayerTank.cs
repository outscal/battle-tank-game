using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player tank inherited from MonoSingletonGeneric class.
/// </summary>
namespace Outscal.BattleTank3DProject
{
    public class PlayerTank : MonoSingletonGeneric<PlayerTank>
    {
        protected override void Awake()
        {
            base.Awake();
            // Custom logic
            Debug.Log("Player Tank");
        }
    }
}