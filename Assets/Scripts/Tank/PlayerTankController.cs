using Attack;
using Bullet;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Tank
{
    public class PlayerTankController : TankController
    {
        private InputSystem.InputSystem _inputSystem;
        private Rigidbody _rigidbody;
        private Vector2 _joystickDirection;

        private bool firing = false;
    
        void TakeJoystickInputs()
        {
            _joystickDirection = _inputSystem.Joystick.Direction;
        }
        public override void Move()
        {
            TakeJoystickInputs();
            Vector3 newForward =(_joystickDirection.magnitude<0.2f)?TankView.transform.forward:new Vector3(_joystickDirection.x , 0, _joystickDirection.y );
            newForward = (newForward*TankModel.Speed).normalized;
            TankView.transform.forward = newForward;
            if(_joystickDirection.magnitude>0.02f)TankView.transform.eulerAngles += Vector3.up * 60;
            Vector3 newVelocity = TankModel.Speed * _joystickDirection.magnitude * TankView.transform.forward;
            _rigidbody.velocity = newVelocity;
        
        }
        public override void HandleAttacks()
        {
            if (_inputSystem.FireButton.Pressed && firing == false)
            {
                Attack.Attack attack = new LinearAttack(TankModel.BulletType, TankView.ShootingPoint
                        .position,
                    TankModel.Damage, TankView.transform.forward);
                BulletService.Instance.CreateBullet(attack);
                firing = true;
            }
            else if(!_inputSystem.FireButton.Pressed && firing == true)
            {
                firing = false;
            }
        }
        public PlayerTankController(InputSystem.InputSystem inputSystem, Scriptable_Object.Tank.Tank tank):base(tank.TankView)
        {
            _inputSystem = inputSystem;
            _rigidbody = TankView.GetComponent<Rigidbody>();
            TankModel = new TankModel(tank.TankModel);
        }
    }
}