using UnityEngine;
using GameServices;

namespace TankServices
{
    public class TankController
    {
        //private Joystick joystick;
        private Joystick leftJoystick;

        private Rigidbody tankRigidbody; // player tank rigidbody reference.

        public TankModel tankModel { get; }
        public TankView tankView { get; }

        // model <- controller -> view
        public TankController(TankModel _tankModel, TankView tankPrefab)
        {
            tankModel = _tankModel;
            
            // Spawns player tank.
            tankView = GameObject.Instantiate<TankView>(tankPrefab, TankSpawnPointService.Instance.GetPlayerSpawnPoint());

            tankRigidbody = tankView.GetComponent<Rigidbody>();
            tankView.SetTankControllerReference(this);
            tankModel.SetTankControllerReference(this);

            Debug.Log("tank Spawner");
        }

        // Sets the reference to joystick on the Canvas.
        public void SetJoystickReference(Joystick _leftJoystick)
        {
            leftJoystick = _leftJoystick;
        }

        // This method is called on every fixed update. // To do all physics calculations.
        public void UpdateTankController()
        {
                if (leftJoystick.Vertical != 0)
                {
                    ForwardMovementInput();
                }
                if (leftJoystick.Horizontal != 0)
                {
                    RotationInput();
                }
        }

        // Forward and backward direction movement based on vertical input of joystick.
        private void ForwardMovementInput()
        {
            Vector3 forwardInput = tankRigidbody.transform.position + leftJoystick.Vertical * tankRigidbody.transform.forward * tankModel.MovementSpeed * Time.deltaTime;

            tankRigidbody.MovePosition(forwardInput);
        }

        // Rotates tank based on horizontal input of joystick.
        private void RotationInput()
        {
            Quaternion desiredRotation = tankRigidbody.transform.rotation * Quaternion.Euler(Vector3.up * leftJoystick.Horizontal * tankModel.RotationSpeed * Time.deltaTime);

            tankRigidbody.MoveRotation(desiredRotation);
        }
    }
}
