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

        private void Update()
        {
            float rotation = Input.GetAxisRaw("Horizontal");
            float movement = Input.GetAxisRaw("Vertical");
            tankController.TankMovement(movement);
            tankController.TankRotation(rotation);
        }
        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }
    }
}