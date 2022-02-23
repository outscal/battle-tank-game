using UnityEngine;

namespace Tank
{
    public class PlayerTankController : TankController
    {
        Joystick _joystick;
        private Rigidbody _rigidbody;
        private Vector2 _joystickDirection;
    
        void TakeJoystickInputs()
        {
            _joystickDirection = _joystick.Direction;
        }
    

        public override void Move()
        {
            TakeJoystickInputs();
            Vector3 newForward =(_joystickDirection.magnitude<0.2f)?TankView.transform.forward:new Vector3(_joystickDirection.x , 0,
                _joystickDirection.y );;
            newForward = (newForward*TankModel.Speed).normalized;
            TankView.transform.forward = newForward;
            if(_joystickDirection.magnitude>0.02f)TankView.transform.eulerAngles += Vector3.up * 60;
            Vector3 newVelocity = TankModel.Speed * _joystickDirection.magnitude * TankView.transform.forward;
            _rigidbody.velocity = newVelocity;
        
        }


        public PlayerTankController(Joystick joystick, Scriptble_Object.Tank.Tank tank) : base(tank.TankView)
        {
            _joystick = joystick;
            _rigidbody = TankView.GetComponent<Rigidbody>();
            TankModel = new TankModel(tank.TankModel);
        }
    }
}