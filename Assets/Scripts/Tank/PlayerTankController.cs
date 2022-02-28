using Attack;
using Bullet;
using UnityEngine;

namespace Tank
{
    public class PlayerTankController : TankController
    {
        
        private Rigidbody _rigidbody;
        private Vector2 _joystickDirection;

        private bool _firing;
    
        void TakeJoystickInputs()
        {
            _joystickDirection = ((PlayerTankView)TankView).InputSystem.Joystick.Direction;
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
            if (((PlayerTankView)TankView).InputSystem.FireButton.Pressed && _firing == false)
            {
                Debug.Log("Firing");
                Attack.Attack attack = new LinearAttack(TankModel.BulletType, TankView.ShootingPoint.position, TankModel.Damage, TankView.transform.forward);
                BulletService.Instance.CreateBullet(attack);
                _firing = true;
            }
            else if (!((PlayerTankView)TankView).InputSystem.FireButton.Pressed && _firing) _firing = false;
        }
        
        public PlayerTankController(InputSystem.InputSystem inputSystem, Scriptable_Object.Tank.Tank tank):base(tank.TankView)
        {
            ((PlayerTankView)TankView).SetInputSystem(inputSystem);
            _rigidbody = TankView.GetComponent<Rigidbody>();
            TankModel = new TankModel(tank.TankModel);
        }

        protected override void DestroyMe()
        {
            base.DestroyMe();
            PlayerTankService.Instance.Destroy();
            //((ITankService)PlayerTankService.Instance).Destroy(this);
        }

        public override void HitBy(Collision collision)
        {
            base.HitBy(collision);
            if(collision.gameObject.GetComponent<EnemyTankView>()) TakeDamage(collision.gameObject.GetComponent<EnemyTankView>().TankController.TankModel.Damage);
        }
    }
}