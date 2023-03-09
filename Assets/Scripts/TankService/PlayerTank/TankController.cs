using TankBattle.Extensions;
using UnityEngine;

namespace TankBattle.Tank.PlayerTank.MoveController
{
    public class TankController
    {
        private Rigidbody rb;

        public TankController(Model.TankModel _tankModel, View.TankView tankPrefab, Color color)
        {
            tankModel = _tankModel;
            tankView = Object.Instantiate(tankPrefab);
            tankView.SetColorOnAllRenderers(color);
        }
        
        public void MoveRotate(Vector2 _moveDirection)
        {
            Vector3 directionVector = _moveDirection.switchYAndZValues();
            Move(directionVector);
            Rotate(directionVector);
        }

        private void Move(Vector3 moveDirection)
        {
            if (!rb)
            {
                rb = tankView.getRigidbody();
            }

            rb.MovePosition(rb.position + moveDirection * tankModel.Speed * Time.deltaTime);
        }

        private void Rotate(Vector3 rotateDirection)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotateDirection, Vector3.up);
            targetRotation = Quaternion.RotateTowards
            (
                tankView.transform.localRotation,
                targetRotation,
                tankModel.RotateSpeed * Time.fixedDeltaTime
            );

            rb.MoveRotation(targetRotation);
        }

        public void Jump()
        {
            if (!rb)
            {
                rb = tankView.GetComponent<Rigidbody>();
            }
            rb.AddForce(Vector3.up * tankModel.JumpForce * Time.deltaTime, ForceMode.Impulse);
        }



        public Model.TankModel tankModel { get; }
        public View.TankView tankView { get; }
    };
}