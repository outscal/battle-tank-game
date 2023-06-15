using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class TankController
    {
        private Rigidbody tankRigidbody;

        public TankModel TankModel { get; private set; }
        public TankView TankView { get; private set; }

        public TankController(TankModel _tankmodel, TankView _tankview)
        {
            TankModel = _tankmodel;
            TankView = GameObject.Instantiate<TankView>(_tankview);
            tankRigidbody = TankView.GetRigidbody();

            TankModel.SetTankController(this);
            TankView.SetTankController(this);
        }

        public void Move(float movementInput, float movementSpeed)
        {
            tankRigidbody.velocity = TankView.transform.forward * movementInput * movementSpeed * Time.deltaTime;
        }

        public void Turn(float rotationInput, float rotationSpeed)
        {
            float turn = rotationInput * rotationSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            tankRigidbody.MoveRotation(tankRigidbody.rotation * turnRotation);
        }
    }
}