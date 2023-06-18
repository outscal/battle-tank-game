using UnityEngine;

namespace BattleTank.PlayerTank
{
    [RequireComponent (typeof(Rigidbody))]
    public class TankView : MonoBehaviour
    {
        Rigidbody tankRigidbody;
        public TankType tankType;

        private float movementInput;
        private float rotationInput;

        public TankController TankController { get; private set; }

        public void SetTankController(TankController tankController)
        {
            TankController = tankController;
        }

        private void Awake()
        {
            tankRigidbody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            Debug.Log("Tank view is created : " + TankController.TankView);
        }

        void Update()
        {
            Movement();

            if (movementInput != 0)
            {
                TankController.Move(movementInput, TankController.TankModel.MovementSpeed);
            }
            else
            {
                tankRigidbody.velocity = Vector3.zero;
            }


            if (rotationInput != 0)
            {
                TankController.Turn(rotationInput, TankController.TankModel.RotationSpeed);
            }
        }

        void Movement()
        {
            movementInput = Input.GetAxisRaw("Horizontal1");
            rotationInput = Input.GetAxisRaw("Vertical1");
        }

        public Rigidbody GetRigidbody()
        {
            return tankRigidbody;
        }
    }
}