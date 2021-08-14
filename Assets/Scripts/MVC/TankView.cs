using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// this class handles the tankview logic 
    /// it inherits Monobehaviours
    /// </summary>
    public class TankView : GenericMonoSingletone
    {
        void Start()
        {
            Debug.Log("tank view created");
        }
    }
}