using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// this class instantiates the tank model in game
    /// </summary>
    public class TankController
    {
        
        private Rigidbody rigidbody;
       // private Vector3 movement;
     
        public TankModel TankModel { get; private set; }
        public TankView TankView { get; private set; }

        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
            rigidbody = TankView.GetComponent<Rigidbody>();
            TankView.SetTankController(this);
            TankModel.SetTankController(this);
 
            Debug.Log("tank prefab instantiated");
        }


        public void TankMovement(float movement)
        {
            Vector3 mov = TankView.transform.position;
            mov += movement * TankModel.Speed * Time.deltaTime * TankView.transform.forward;
            rigidbody.MovePosition(mov);

        }

        public void TankRotation(float rotation)
        {
            Vector3 vector = new Vector3(0f, rotation * TankModel.rotationSpeed, 0f);
            //Vector3 vector = new Vector3(0f, rotation * 10, 0f);
            Quaternion angle = Quaternion.Euler(vector * Time.fixedDeltaTime);
            rigidbody.MoveRotation(angle * rigidbody.rotation);
        }
    }
}