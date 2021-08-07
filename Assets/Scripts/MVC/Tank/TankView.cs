using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// this class handles the tankview logic 
    /// it inherits Monobehaviours
    /// </summary>
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        [SerializeField] private TankType tankType;
        void Start()
        {
            Debug.Log("tank view created");
        }
        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }
    }
}