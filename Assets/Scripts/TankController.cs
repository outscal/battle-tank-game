using UnityEngine;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankController : MonoBehaviour
    {
        FloatingJoystick joystick;

        [SerializeField]
        float moveSpeed;

        [SerializeField]
        Transform chassis;

        Rigidbody rb;
        float horizontalInput, verticalInput;
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void SetupJoystick(FloatingJoystick js)
        {
            joystick = js;
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
