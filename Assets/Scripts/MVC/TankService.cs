using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// service class that 
    /// </summary>
    public class TankService : MonoBehaviour
    {
        [SerializeField] private TankView tankView;
        void Start()
        {
            TankModel model = new TankModel(5, 100f);
            TankController tank = new TankController(model, tankView);
        }


    }
}