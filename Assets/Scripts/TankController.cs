using Singleton;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankController : MonoSingletonGeneric<TankController>
    {
        [SerializeField]
        FloatingJoystick joystick;

        [SerializeField]
        float moveSpeed;

        [SerializeField]
        Transform chassis;

        Rigidbody rb;
        float horizontalInput, verticalInput;
        protected override void Awake()
        {
            base.Awake();
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (horizontalInput != 0 || verticalInput != 0)
                rb.AddForce(chassis.transform.forward * moveSpeed * Time.deltaTime,ForceMode.Impulse);
        }
        private void Update()
        {
             horizontalInput = joystick.Horizontal;
             verticalInput = joystick.Vertical;
            if(horizontalInput!=0 || verticalInput != 0)
            chassis.transform.localEulerAngles = new Vector3(0, (Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg)+45f, 0);
        }
    }
}
